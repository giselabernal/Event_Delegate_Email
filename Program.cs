namespace Event_Delegate_Email
{
    internal class Program
    {
        delegate void MyCustomDelegate();
        //create the delegate to handle the email notification
        delegate void EmailSentNotificationDelegate(string notificationMsg);
        static void Main(string[] args)
        {
            //MyCustomDelegate myCustomDelegate = new MyCustomDelegate(SendMailtoAllGoldMembers);
            //myCustomDelegate.Invoke();

            //normal without delegate
            // SendMailtoAllGoldMembers();  

            SendMailtoAllGoldMembers(WriteEmailSentNotificationOnConsole);
            SendMailtoAllGoldMembers(WriteEmailSentNotificationinLogFile);  
            SendMailtoAllGoldMembers(WriteEmailSentNotificationinDatabase);  
        }

        static void SendMailtoAllGoldMembers()
        {
            foreach (var emailId in GetListofEmailIdForGoldMembers())
            {
                //logic for sending the mail to all the gold members  
                System.Threading.Thread.Sleep(2000); //assuming that it will take 2 seconds to send a mail.  
                Console.WriteLine($"Email Id {emailId} : mail sent");
            }
        }
        //what happened if instead of writing on console I want to wirte the log into a log file
        //chage line 21 to 
        //System.IO.File.AppendAllText(@ "D:\\delexample\log.txt", $ "\n Email Id {emailId} : mail sent");
        //What if instead of writing on log file we want it to a database?
        //line 21 would change to 
        // InsertTheLogDetailsIntoDatabase($ "Email Id {emailId} : mail sent");  
        static List<string> GetListofEmailIdForGoldMembers()
        {
            List<string> ListOfEmailIds = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                ListOfEmailIds.Add($"member{i.ToString("D4")}@gmail.com");
            }
            return ListOfEmailIds;
        }

        //after creating delegate, we have to create the method or methods
        //Create a method to send the email messages
        static void SendMailtoAllGoldMembers(EmailSentNotificationDelegate EmailSentNotification)
        {
            foreach (var emailId in GetListofEmailIdForGoldMembers())
            {
                //logic for sending the mail to all the gold members  
                System.Threading.Thread.Sleep(2000); //assuming that it will take 2 seconds to send a mail.   
                EmailSentNotification($"Email Id {emailId} : mail sent");
            }
        }

        //Create a method for writing log in console window
        static void WriteEmailSentNotificationOnConsole(string notificationMsg)
        {
            Console.WriteLine(notificationMsg);
        }

        //Create a method to write log in log file
        static void WriteEmailSentNotificationinLogFile(string notificationMsg)
        {
            System.IO.File.AppendAllText(@"c:\\delexample\log.txt", $"\n {notificationMsg}");
        }
        //Create a method to write log in database
        static void WriteEmailSentNotificationinDatabase(string notificationMsg)
        {
            InsertTheLogDetailsIntoDatabase(notificationMsg);
        }

        static void InsertTheLogDetailsIntoDatabase(string notificationMsg)
        {
            throw new NotImplementedException();
        }
    }
}