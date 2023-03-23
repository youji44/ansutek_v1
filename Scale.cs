using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OperatorUI
{

    /// <summary>
    /// This scale class implements the SICS interface described in the Mettler-Toledo manuals
    /// https://www.mt.com/dam/product_organizations/industry/IndustrialTerminals/30205308_R07_MAN_IND570_UG_EN.pdf
    /// See section C-20 for the IND570 command section
    /// </summary>
    public class Scale
    {
        public string IP { get; private set; }
        public int Port { get; private set; }
        private TcpClient Client { get; }

        public bool IsConnected => Client.Connected;

        public Scale(string ip, int port)
        {
            IP = ip;
            Port = port;

            Client = new TcpClient();
        }


        /// <summary>
        /// Scale Responses: (_ -> Space notation)
        /// S _ S _ WeightValue _ Unit – Stable weight value
        /// S _ D _ WeightValue _ Unit – Non-stable weight value
        /// S _ I – The command is understood but cannot be executed at this time. (scale is busy)
        /// S _ + – IND570 in overload range.
        /// S _ - – IND570 in underload range.
        /// </summary>
        /// <param name="weightString"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool TryGetScaleWeight(out string weightString, out Exception error)
        {
            if (!Client.Connected)
            {
                try
                {
                    Client.ReceiveTimeout = 1000;
                    Client.SendTimeout = 1000;
                    Client.Connect(IP, Port);                   
                }
                catch (Exception ex)
                {
                    //To do: Ping scale to see if offline or not configured
                    error = ex;
                    weightString = ("-------");
                    return false;
                }
            }

            try
            {
                NetworkStream nwStream = Client.GetStream();
                byte[] buffer = new byte[Client.ReceiveBufferSize];

                byte[] request = Encoding.ASCII.GetBytes("SI\r\n");
                nwStream.Write(request, 0, request.Length);

                int bytesRead = nwStream.Read(buffer, 0, Client.ReceiveBufferSize);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);


                error = null;
                weightString = ParseScaleResponse(response);
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                weightString = "-------";
                return false;
            }
        }

        /// <summary>
        /// Scale Responses: (_ -> Space notation)
        /// S _ S _ WeightValue _ Unit – Stable weight value
        /// S _ D _ WeightValue _ Unit – Non-stable weight value
        /// S _ I – The command is understood but cannot be executed at this time. (scale is busy)
        /// S _ + – IND570 in overload range.
        /// S _ - – IND570 in underload range.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string ParseScaleResponse(string response)
        {
            if (String.IsNullOrEmpty(response))
            {
                return "-------";
            }
            else if (response.Contains("+"))
            {
                return "-------"; //Overloaded
            }
            // else if (response.Contains("-"))
            // {
            //    return "-------"; //Under Zero
            //}
            else if (response.Contains("S I"))
            {
                return "-------"; //Could not read, scale busy
            }
            else
            {
                //Split the response on spaces, and remove empty entries caused by padding
                //See LINQ for more detail on .Where
                var data = response.Split(' ').Where(s => !String.IsNullOrEmpty(s)).ToArray();

                //data[0] S data[1] S||D => Stable||Unstable
                //data[2] Weight data[3] unit

                //Todo: Add weight status to response ~
                return $"{data[2]}";
            }
        }
    }
}
