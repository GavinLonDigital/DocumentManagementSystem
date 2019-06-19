using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManagementSystemAPI
{
   public class DMS
    {
        public DMS()
        {

        }

        public bool CreateDocument(string name, string description, ref int id)
        {
            int webCallResult = 0;
            bool success = false;

            //Call to web method that adds new document to DMS goes here

            webCallResult = 8; //call to web method returns 8 after adding new document to DMS

            if (webCallResult != 0)
            {
                success = true;
            }

            id = webCallResult;

            return success;
        }
        public int CreateDocument(string name)
        {

            //Call to web method that adds new document to DMS goes here
            int webCallResult = 8;

            return webCallResult;

        }
        public DMSDocumentBST GetDMSDocumentBST(int[] sortedArray)
        {
            return new DMSDocumentBST(sortedArray);
        }
    }
}
