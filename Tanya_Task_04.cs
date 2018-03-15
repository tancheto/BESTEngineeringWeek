using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public struct Item
        {
            public string free;
            public string price;
        };
        public struct Plan
        {
            public string planID;
            public string planName;
            public string planPrice;
            public Item calls;
            public Item data;
            public Item sms;
            public Item mms;

        };

        public struct Customer
        {
            public string clientID;
            public string clientName;
            public string planPerClientID;

            public int callsNum;
            public int dataNum;
            public int smsNum;
            public int mmsNum;

            public int callsAm;
            public int dataAm;
            public int smsAm;
            public int mmsAm;
        };

        public struct Network
        {
            public string ClientID;
            public string Event;
            public string Amount;

        };

        static void Main(string[] args)
        {

            string fileRating = @"C:\Users\dev\Desktop\BEST_2018\Task_04\rating.cfg";
            var iStreamRating = new FileStream(fileRating, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var readerRating = new System.IO.StreamReader(iStreamRating);

            string[] lines = System.IO.File.ReadAllLines(fileRating);

            int currentLine = 0;
            Plan[] arrPlan = new Plan[lines.Length];

            int counter = 0;

            foreach (string line in lines)
            {

                if (currentLine == 0)
                {
                    string[] words = line.Split('|');
                    arrPlan[counter].planID = words[0];
                    arrPlan[counter].planName = words[1];
                    arrPlan[counter].planPrice = words[2];
                    currentLine++;
                }
                else if (currentLine == 1)
                {
                    string[] words = line.Split('|');
                    arrPlan[counter].calls.free = words[1];
                    arrPlan[counter].calls.price = words[2];
                    currentLine++;

                }
                else if (currentLine == 2)
                {
                    string[] words = line.Split('|');
                    arrPlan[counter].data.free = words[1];
                    arrPlan[counter].data.price = words[2];
                    currentLine++;

                }
                else if (currentLine == 3)
                {
                    string[] words = line.Split('|');
                    arrPlan[counter].sms.free = words[1];
                    arrPlan[counter].sms.price = words[2];
                    currentLine++;

                }
                else if (currentLine == 4)
                {
                    string[] words = line.Split('|');
                    arrPlan[counter].mms.free = words[1];
                    arrPlan[counter].mms.price = words[2];
                    currentLine++;

                }
                else if (currentLine == 5)
                {
                    currentLine = 0;
                    counter++;
                }
            }

            readerRating.Close();

            string fileCustomer = @"C:\Users\dev\Desktop\BEST_2018\Task_04\customer.cfg";
            var iStreamCustomer = new FileStream(fileCustomer, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var readerCustomer = new System.IO.StreamReader(iStreamCustomer);

            lines = System.IO.File.ReadAllLines(fileCustomer);


            counter = 0;

            Customer[] arrCus = new Customer[lines.Length];
            int numClients = lines.Length;
          //  Console.WriteLine("The Number of clients:{0}",numClients);

            foreach (string line in lines)
            {
                string[] words = line.Split('|');
                arrCus[counter].clientID = words[0];
                arrCus[counter].clientName = words[1];
                arrCus[counter].planPerClientID = words[2];

                arrCus[counter].callsNum = 0;//zanulqvane
                arrCus[counter].dataNum = 0;
                arrCus[counter].smsNum = 0;
                arrCus[counter].mmsNum = 0;

                arrCus[counter].callsAm = 0;
                arrCus[counter].dataAm = 0;
                arrCus[counter].smsAm = 0;
                arrCus[counter].mmsAm = 0;

                counter++;
            }

            readerCustomer.Close();

            string fileNet = @"C:\Users\dev\Desktop\BEST_2018\Task_04\network.edr";
            var iStreamNet = new FileStream(fileNet, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var readerNet = new System.IO.StreamReader(iStreamNet);

            lines = System.IO.File.ReadAllLines(fileNet);

            currentLine = 0;
            Network[] arrNet = new Network[lines.Length];
            counter = 0;


            foreach (string line in lines)
            {
                string[] words = line.Split('|');
                arrNet[counter].ClientID = words[0];
                arrNet[counter].Event = words[1];
                arrNet[counter].Amount = words[2];
                int curAmountInt = Int32.Parse(arrNet[counter].Amount);

                switch (arrNet[counter].ClientID)
                {
                    case "1":
                        if (arrNet[counter].Event == "calls")
                        {arrCus[0].callsNum++; arrCus[0].callsAm += curAmountInt;}
                        else if (arrNet[counter].Event == "data")
                        { arrCus[0].dataNum++; arrCus[0].dataAm += curAmountInt;}
                        else if (arrNet[counter].Event == "sms")
                        { arrCus[0].smsNum++; arrCus[0].smsAm += curAmountInt;}
                        else if (arrNet[counter].Event == "mms")
                        { arrCus[0].mmsNum++; arrCus[0].mmsAm += curAmountInt;}
                        break;
                    case "2":
                        if (arrNet[counter].Event == "calls")
                        { arrCus[1].callsNum++; arrCus[1].callsAm += curAmountInt; }
                        else if (arrNet[counter].Event == "data")
                        { arrCus[1].dataNum++; arrCus[1].dataAm += curAmountInt; }
                        else if (arrNet[counter].Event == "sms")
                        { arrCus[1].smsNum++; arrCus[1].smsAm += curAmountInt; }
                        else if (arrNet[counter].Event == "mms")
                        { arrCus[1].mmsNum++; arrCus[1].mmsAm += curAmountInt; }
                        break;
                    case "3":
                        if (arrNet[counter].Event == "calls")
                        { arrCus[2].callsNum++; arrCus[2].callsAm += curAmountInt; }
                        else if (arrNet[counter].Event == "data")
                        { arrCus[2].dataNum++; arrCus[2].dataAm += curAmountInt; }
                        else if (arrNet[counter].Event == "sms")
                        { arrCus[2].smsNum++; arrCus[2].smsAm += curAmountInt; }
                        else if (arrNet[counter].Event == "mms")
                        { arrCus[2].mmsNum++; arrCus[2].mmsAm += curAmountInt; }
                        break;
                    case "4":
                        if (arrNet[counter].Event == "calls")
                        { arrCus[3].callsNum++; arrCus[3].callsAm += curAmountInt; }
                        else if (arrNet[counter].Event == "data")
                        { arrCus[3].dataNum++; arrCus[3].dataAm += curAmountInt; }
                        else if (arrNet[counter].Event == "sms")
                        { arrCus[3].smsNum++; arrCus[3].smsAm += curAmountInt; }
                        else if (arrNet[counter].Event == "mms")
                        { arrCus[3].mmsNum++; arrCus[3].mmsAm += curAmountInt; }
                        break;
                }

                counter++;

            }
            readerNet.Close();

            string fileBill = @"C:\Users\dev\Desktop\BEST_2018\Task_04\bill.data";

            var oStreamBill = new FileStream(fileBill, FileMode.Append, FileAccess.Write, FileShare.Read);

            var writerBill = new System.IO.StreamWriter(oStreamBill);

            for(int curClient=0; curClient<numClients; curClient++)
            {
                int curPlanID = Int32.Parse(arrCus[curClient].planPerClientID)-1;

                //calls
                int usedFreeCalls, taxedCalls;
                double priceCalls;

                if (Int32.Parse(arrPlan[curPlanID].calls.free) > arrCus[curClient].callsAm) { usedFreeCalls = arrCus[curClient].callsAm; }
                else { usedFreeCalls = Int32.Parse(arrPlan[curPlanID].calls.free); }

                taxedCalls = arrCus[curClient].callsAm - usedFreeCalls;

                priceCalls = taxedCalls * Convert.ToDouble(arrPlan[curPlanID].calls.price);
                string priceCallsStr = string.Format("{0:0.00}", priceCalls);

                //data

                int usedFreeData, taxedData;
                double priceData;

                if (Int32.Parse(arrPlan[curPlanID].data.free) > arrCus[curClient].dataAm) { usedFreeData = arrCus[curClient].dataAm; }
                else { usedFreeData = Int32.Parse(arrPlan[curPlanID].data.free); }

                taxedData = arrCus[curClient].dataAm - usedFreeData;

                priceData = taxedData * Convert.ToDouble(arrPlan[curPlanID].data.price);
                string priceDataStr = string.Format("{0:0.00}", priceData);

                //sms

                int usedFreeSms, taxedSms;
                double priceSms;

                if (Int32.Parse(arrPlan[curPlanID].sms.free) > arrCus[curClient].smsAm) { usedFreeSms = arrCus[curClient].smsAm; }
                else { usedFreeSms = Int32.Parse(arrPlan[curPlanID].sms.free); }

                taxedSms = arrCus[curClient].smsAm - usedFreeSms;

                priceSms = taxedSms * Convert.ToDouble(arrPlan[curPlanID].sms.price);
                string priceSmsStr = string.Format("{0:0.00}", priceSms);

                //mms

                int usedFreeMms, taxedMms;
                double priceMms;

                if (Int32.Parse(arrPlan[curPlanID].mms.free) > arrCus[curClient].mmsAm) { usedFreeMms = arrCus[curClient].mmsAm; }
                else { usedFreeMms = Int32.Parse(arrPlan[curPlanID].mms.free); }

                taxedMms = arrCus[curClient].mmsAm - usedFreeMms;

                priceMms = taxedMms * Convert.ToDouble(arrPlan[curPlanID].mms.price);
                string priceMmsStr = string.Format("{0:0.00}", priceMms);


                writerBill.WriteLine("{0}|{1}|{2}|{3}",arrCus[curClient].clientID,arrCus[curClient].clientName, arrPlan[curPlanID].planName, arrPlan[curPlanID].planPrice);

                writerBill.WriteLine("calls|{0}|{1}|{2}|{3}|{4}|{5}", arrCus[curClient].callsNum, arrCus[curClient].callsAm, arrPlan[curPlanID].calls.free, usedFreeCalls, taxedCalls, priceCallsStr);

                writerBill.WriteLine("data|{0}|{1}|{2}|{3}|{4}", arrCus[curClient].dataAm, arrPlan[curPlanID].data.free, usedFreeData, taxedData, priceDataStr);

                writerBill.WriteLine("sms|{0}|{1}|{2}|{3}|{4}", arrCus[curClient].smsAm, arrPlan[curPlanID].sms.free, usedFreeSms, taxedSms, priceSmsStr);

                writerBill.WriteLine("mms|{0}|{1}|{2}|{3}|{4}", arrCus[curClient].mmsAm, arrPlan[curPlanID].mms.free, usedFreeMms, taxedMms, priceMmsStr);

                writerBill.WriteLine();

            }

            writerBill.Close();

        }
    }
}
