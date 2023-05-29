using Azure.Storage.Blobs;
using System;

namespace BlobServiceApp
{
    internal class Program
    {
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=alexeiappstore;AccountKey=oVw8iTQJfDbXXVBlZLYwE194uR+FStPPLdtEsuy+T2M/uJ+Yd/HG7LONFd+V4/E8YFI7+Hl1i7kv+AStzYwYsQ==;EndpointSuffix=core.windows.net";
        private static string container_name = "data";
        private static string local_blob = "\\app\\Courses.json";
        private static string blob_name = "Courses.json";

        static void Main(string[] args)
        {
            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);


            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            _blob_client.DownloadTo(local_blob);

            Console.WriteLine("Blob downloaded");

        }
    }
}
