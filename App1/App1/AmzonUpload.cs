using System;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.IO;

namespace App1
{
    public class AmazonUpload
    {
        private string bucketName = "missions69";      //папка в интернете (корзина)
        //private string keyName = "mission69.xml";        // название файла в папке в инете
        //private string filePath = "App1.dmissions.xml"; //путь файла для отправления/загрузки
        //private string dfilePath = "App1.missions.xml";
        
       
       
        public async void DownloadFile(string path,string key)
        {
            AmazonS3Config config = new AmazonS3Config();
            //config.ServiceURL = "https://missions69.s3.eu-west-3.amazonaws.com/missions.xml" ;
            config.UseHttp = true;
            config.RegionEndpoint = Amazon.RegionEndpoint.EUWest3;

            var client = new AmazonS3Client("AKIAJO3YO2ATRVV5UQYA", "4+SelI41UmF0oO8IiXazTizmLy60C82Eaem2nonH",config);
            Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
            TransferUtility transferUtility = new TransferUtility(client);
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();
            request.Key = key;
            request.BucketName = bucketName;
            request.FilePath = path;
            System.Threading.CancellationToken cancellationToken = new System.Threading.CancellationToken();
            await transferUtility.DownloadAsync(request, cancellationToken);
        }
        public async void UploadFile(string path, string key)
        {
            AmazonS3Config config = new AmazonS3Config();
            //config.ServiceURL = "https://missions69.s3.eu-west-3.amazonaws.com/missions.xml" ;
            config.UseHttp = true;
            config.RegionEndpoint = Amazon.RegionEndpoint.EUWest3;

            var client = new AmazonS3Client("AKIAJO3YO2ATRVV5UQYA", "4+SelI41UmF0oO8IiXazTizmLy60C82Eaem2nonH", config);

            TransferUtility transferUtility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.Key = key;
            request.BucketName = bucketName;
            request.FilePath = path;
            System.Threading.CancellationToken cancellationToken = new System.Threading.CancellationToken();
            await transferUtility.UploadAsync(request, cancellationToken);
        }
        //public void UploadFile()
        //{
        //    var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest3);

        //    try
        //    {
        //        PutObjectRequest putRequest = new PutObjectRequest
        //        {
        //            BucketName = bucketName,
        //            Key = keyName,
        //            FilePath = filePath,
        //            ContentType = "text/plain"
        //        };
        //        PutObjectResponse response = client.PutObject(putRequest);
        //    }
        //    catch (AmazonS3Exception amazonS3Exception)
        //    {
        //        if (amazonS3Exception.ErrorCode != null &&
        //            (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
        //            ||
        //            amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
        //        {
        //            throw new Exception("Check the provided AWS Credentials.");
        //        }
        //        else
        //        {
        //            throw new Exception("Error occurred: " + amazonS3Exception.Message);
        //        }
        //    }
        //}

    }
}