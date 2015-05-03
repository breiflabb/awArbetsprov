using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;
using System.Diagnostics;



namespace awConsole
{
    class Program
    {
        static string lineBreak = "nyradhäreftersomingetannatfunkar"; //Exixts due to a problem with \n in Console.WriteLine
        static void Main(string[] args)
        {

            while (true) //infinite loop so that the user can write messages repeatedly
            {
                
                string postPage = "http://localhost:3456//getMessage.aspx?Message="; //Url to send the message to
                string userInput = getUserInput();
                
                if (userInput == "exit") //Breaks out of the loop if the user enter the "safe word"
                {
                    break;
                }

                string url = postPage + userInput;
                string response = sendRequest(url);
                response = response.Replace(lineBreak, System.Environment.NewLine);//Fix of new lines

                //Some user feedback
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Följande svar genererades från webbsystemet:");
                Console.WriteLine();
                if (response == userInput)
                {
                    response = "Ditt meddelande har sparats!";
                }
                Console.WriteLine(response);

            }
        }

        //Get message from the user
        static string getUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("Skriv in ditt meddelande! Skicka genom att trycka på Entertangenten.");
            Console.WriteLine("För att avsluta, skicka meddelandet \"exit\".");
            string retur = Console.ReadLine();
            return retur;
        }
       
        //Sends the request to and reads the response from the web server returns string for user feedback.
        static string sendRequest(string S)
        {
            string outPut="";
            using (WebClient Client = new WebClient())
            {
                try
                {
                    using (Stream responseStream = Client.OpenRead(S))
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string lineToRead;
                            while ((lineToRead = responseReader.ReadLine()) != null)
                            {
                                //finds the value of the recieved message in the response
                                if (lineToRead.IndexOf("messagePostMessage") != -1)
                                {
                                    int startRead = lineToRead.IndexOf("messagePostMessage") + 18;
                                    int stopRead = lineToRead.IndexOf("endMessagePostMessage", startRead);
                                    int posToRead = stopRead - startRead;
                                    outPut = lineToRead.Substring(startRead, posToRead);
                                }
                            }
                        }
                    }
                }
                //Some error handling with user feedback string
                catch (Exception e)
                {
                    outPut =    "Något gick fel."
                                + lineBreak
                                + "Följande felmeddelande genererades:"
                                + e.Message.ToString();
                   
                }
            }
            return outPut;
        }
    }
}
