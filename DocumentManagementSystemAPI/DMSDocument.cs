using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystemAPI
{
    public class DMSDocument : Document
    {
        private const string docType = "DMS Document";

        public DMSDocument(int id) : base(id)
        {

        }

        public async Task<string> DownloadContent()
        {
            Task<string> downloadTask = Download();

            string content = await downloadTask;

            return content;

        }

        private async Task<string> Download()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");

            await Task.Delay(6000); //simulation of call to web service to download document content

            return sb.ToString();

        }

        public override string GetSerializedDocumentMetadata(DocumentMetaDataFormat documentMetaDataFormat)
        {
            return base.GetSerializedDocumentMetadata(DocumentMetaDataFormat.CSV) + "," + docType;
        }

        public override bool IsDocIdValid(int id)
        {
            if (id >= 1 && id <= 1000)
            {
                return true;
            }
            return false;
        }
    }
}
