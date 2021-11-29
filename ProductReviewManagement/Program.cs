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
            //list.Add(new ProductReview() { ProductId = 1, UserId = 1, Review = "good", Rating = 17, IsLike = true });

            //2 nd method
            //Collection intializer
            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview(){ ProductId=1,UserId=1,Review="good",Rating=17,IsLike=true},
                new ProductReview(){ ProductId=2,UserId=3,Review="bad",Rating=1,IsLike=false},
                new ProductReview(){ ProductId=3,UserId=5,Review="good",Rating=20,IsLike=true},
                new ProductReview(){ ProductId=4,UserId=7,Review="average",Rating=10,IsLike=true},
                new ProductReview(){ ProductId=5,UserId=1,Review="bad",Rating=5,IsLike=false},
                new ProductReview(){ ProductId=6,UserId=5,Review="good",Rating=30,IsLike=true},
                new ProductReview(){ ProductId=7,UserId=7,Review="average",Rating=13,IsLike=true},
                new ProductReview(){ ProductId=8,UserId=1,Review="bad",Rating=2,IsLike=false}
            };
            Console.WriteLine("Top 3 Records : ");
            RetrieveTop3RecordsFromList(list);
            Console.WriteLine("\n");
            Console.WriteLine("Records based on rating and product id : ");
            RetrieveRecordsBasedOnRatingAndProductId(list);
            Console.WriteLine("\n");
            CountingProductId(list);
            Console.WriteLine("\n");
            RetrieveProductIDAndReview(list);
            Console.WriteLine("\n");
            SkipTop5RecordsFromListAndRetrieveOtherData(list);


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

        //This method for retrieve the records based on rating and product identifier.      
        public static void RetrieveRecordsBasedOnRatingAndProductId(List<ProductReview> list)
        {
            var data = (list.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9))).ToList();
            foreach (var element in data)
            {
                Console.WriteLine("ProductId : " + element.ProductId + " Rating : " + element.Rating + " UserId : " + element.UserId + " Review : " + element.Review + " IsLike : " + element.IsLike);
            }
        }

        //This method for counting each Id present in the list
        public static void CountingProductId(List<ProductReview> list)
        {
            var data = list.GroupBy(p => p.ProductId).Select(x => new { productID = x.Key, count = x.Count() });
            foreach (var element in data)
            {
                Console.WriteLine("ProductId " + element.productID + "\t" + "Count " + element.count);
                Console.WriteLine("---------------");
            }
        }

        //This method for Retrieve product id and review from list of all recoprds
        public static void RetrieveProductIDAndReview(List<ProductReview> productReviewsList)
        {
            var p = productReviewsList.Select(product => new { productID = product.ProductId, review = product.Review });
            foreach (var element in p)
            {
                Console.WriteLine("ProductID: " + element.productID + "\t" + "Review:" + element.review);
            }
        }

        //This method for skip top 5 rcords and retrive other data
        public static void SkipTop5RecordsFromListAndRetrieveOtherData(List<ProductReview> list)
        {
            //Query syntax for LINQ 
            var result = (from product in list orderby product.Rating descending select product).Skip(5);
            var remainingRecords = result;
            foreach (ProductReview product in remainingRecords)
            {
                Console.WriteLine("ProductId : " + product.ProductId + " UserId : " + product.UserId + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
            }
        }
    }
}