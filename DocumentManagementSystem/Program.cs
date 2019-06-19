using System;
using System.Threading.Tasks;
using DocumentManagementSystemAPI;

namespace DocumentManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string content = string.Empty;

            DMS dms = new DMS();

            int[] docIds = new int[] {1,2,3,4,5,6,7};

            DMSDocumentBST dmsDocumentBST = dms.GetDMSDocumentBST(docIds);

            int key = 0;

            while (true)
            {
                Console.WriteLine("Please enter a document Id");

                key = Convert.ToInt32(Console.ReadLine());

                Console.Write("Search path: ");
                DMSDocument doc = (DMSDocument)dmsDocumentBST.FindDoc(key);
                Console.Write(key);

                Console.WriteLine();
                Console.WriteLine();

                if (doc != null)
                {
                    Console.WriteLine($"Document - {doc.Id} - has been found");
                    Console.WriteLine("Downloading document content...");

                    content = await doc.DownloadContent();

                    Console.Clear();

                    Console.WriteLine(doc.GetSerializedDocumentMetadata(DocumentMetaDataFormat.CSV));

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine(content);

                    Console.WriteLine();
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine($"Document, {key}, could not be found.");
                }
                if (!SearchDocsAgain()) break;

                Console.Clear();

            }            
        }

        private static bool SearchDocsAgain()
        {
            Console.WriteLine("Please press spacebar to end application or any other key to continue...");

            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                return false;
            }
            return true;
        }

        private static void RepeatMultiply(int x, int multiplier, int limit)
        {
            if (x > limit || x <= 0) //Base Case
                return;

            Console.WriteLine(x);
            x = x * multiplier;

            RepeatMultiply(x, multiplier, limit);

            //while (x < limit && x > 0)
            //{
            //    Console.WriteLine(x);
            //    x = x * multiplier;
            //}
        }

    }
}
