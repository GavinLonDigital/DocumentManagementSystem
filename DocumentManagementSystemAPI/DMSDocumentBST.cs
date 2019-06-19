using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManagementSystemAPI
{
    public class DMSDocumentBST
    {
        private readonly Document _rootDoc = null;
        private readonly List<Document> _documents = null;

        public Document RootDoc
        {
            get
            {
                return _rootDoc;
            }

        }

        public DMSDocumentBST(int[] arr)
        {
            _rootDoc = SortedArrayToBST(arr, 0, arr.Length - 1);

            _documents = new List<Document>();

            CreateInOrderDocumentList(_rootDoc);

        }

        public Document FindDoc(int key)
        {
            return Search(_rootDoc, key);
        }

        private Document Search(Document rootDoc, int key)
        {
            if (rootDoc == null || rootDoc.Id == key) //Base Case
                return rootDoc;

            Console.Write($"{rootDoc.Id} - "); //Print search path

            //key is greater than root's key
            if (rootDoc.Id < key)
                return Search(rootDoc.RightDoc, key);

            //key is smaller than root's key
            return Search(rootDoc.LeftDoc, key);


        }

        /* A function that constructs Balanced Binary 
         Search Tree from sorted array*/
        private Document SortedArrayToBST(int[] arr, int start, int end)
        {
            /*Base Case*/
            if (start > end)
            {
                return null;
            }

            /*Get the middle element and make it root*/
            int mid = (start + end) / 2;
            Document doc = new DMSDocument(arr[mid]);

            /*Recursively construct the left subtree and make it
             left child of root*/
            doc.LeftDoc = SortedArrayToBST(arr, start, mid - 1);

            /*Recursively construct the right subtree and make it
             right child of root*/
            doc.RightDoc = SortedArrayToBST(arr, mid + 1, end);

            return doc;

        }

        public IEnumerable<Document> GetOrderedDocumentList()
        {
            for (int x = 0; x < _documents.Count; x++)
            {
                yield return _documents[x];
            }
        }
        public IEnumerable<Document> GetOrderedDocumentList(bool reverse)
        {
            if (reverse)
            {
                for (int x = _documents.Count - 1; x > -1; x--)
                {
                    yield return _documents[x];
                }
            }
            else
            {
                for (int x = 0; x < _documents.Count; x++)
                {
                    yield return _documents[x];
                }
            }

        }
        //Inorder tree traversal
        private void CreateInOrderDocumentList(Document rootDoc)
        {
            if (rootDoc == null)
                return;

            /* first recur on left child*/
            CreateInOrderDocumentList(rootDoc.LeftDoc);

            /* Add document object to the list*/
            _documents.Add(rootDoc);

            /* now recur on right child*/
            CreateInOrderDocumentList(rootDoc.RightDoc);

        }

        //Function to print level order traversal of the tree
        public void PrintLevelOrder()
        {
            int h = Height(_rootDoc);
            int i;

            for (i = 1; i <= h; i++)
            {
                PrintGivenLevel(_rootDoc, i);
            }
        }

        //Compute the height of tree
        private int Height(Document rootDoc)
        {
            if (rootDoc == null)
            {
                return 0;
            }
            else
            {
                int lheight = Height(rootDoc.LeftDoc);
                int rheight = Height(rootDoc.RightDoc);

                //Use the larger one
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }

        }
        
        //Print document Id for document objects at the given level in the tree
        private void PrintGivenLevel(Document rootDoc, int level)
        {
            if (rootDoc == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(rootDoc.Id + " ");
            }
            else if (level > 1)
            {
                PrintGivenLevel(rootDoc.LeftDoc, level - 1);
                PrintGivenLevel(rootDoc.RightDoc, level - 1);
            }

        }
    }
}
