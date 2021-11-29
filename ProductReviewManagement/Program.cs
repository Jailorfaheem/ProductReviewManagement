using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProductReviewManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1 st method
            //List<ProductReview> list = new List<ProductReview>();
            //list.Add(new ProductReview() { ProductId = 1, UserId = 1, Review = "good", Rating = 15, IsLike = true });

            //2 nd method
            //Collection intializer
            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview(){ ProductId=1,UserId=1,Review="good",Rating=15,IsLike=true},
                new ProductReview(){ ProductId=2,UserId=3,Review="bad",Rating=1,IsLike=false},
                new ProductReview(){ ProductId=3,UserId=5,Review="good",Rating=20,IsLike=true},
                new ProductReview(){ ProductId=4,UserId=7,Review="average",Rating=10,IsLike=true},
                new ProductReview(){ ProductId=5,UserId=1,Review="bad",Rating=5,IsLike=false}
            };
            RetrieveTop3RecordsFromList(list);
            Console.ReadLine();
        }
        //This method for retrieve top three records from list
        public static void RetrieveTop3RecordsFromList(List<ProductReview> list)
        {
            //Query syntax for LINQ 
            var result = from product in list orderby product.Rating descending select product;
            var topThreeRecords = result.Take(3);
            foreach (ProductReview product in topThreeRecords)
            {
                Console.WriteLine("ProductId : " + product.ProductId + " UserId : " + product.UserId + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
            }
        }
    }
}