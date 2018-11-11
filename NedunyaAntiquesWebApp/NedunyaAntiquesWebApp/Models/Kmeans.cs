using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accord.MachineLearning;
using Accord.Math.Distances;

namespace NedunyaAntiquesWebApp.Models
{
    public class k_means
    {

        // Database
        ApplicationContext db = new ApplicationContext();

        public double[] Tolist(Product p)
        {
            if (p.Category == "ריהוט")
                return new double[] { 100, (double)p.Price, (double)p.Depth, (double)p.Height, (double)p.Width };
            else if (p.Category == "כלי מטבח")
                return new double[] { 200, (double)p.Price, (double)p.Depth, (double)p.Height, (double)p.Width };
            else
                return new double[] { 300, (double)p.Price, (double)p.Depth, (double)p.Height, (double)p.Width };
        }
        public int[] k_means2()
        {
            Accord.Math.Random.Generator.Seed = 0;
            // A common desire when doing clustering is to attempt to find how to 
            // weight the different components / columns of a dataset, giving them 
            // different importances depending on the end goal of the clustering task.
            // Declare some observations
            List<Product> allproducts = new List<Product>();
            allproducts.Add((Product)from pd in db.Products where pd.Price > 0 select pd);
            double[][] observations = {
                Tolist(allproducts[0]),
                Tolist(allproducts[1]),
                Tolist(allproducts[2]),
                Tolist(allproducts[3]),
                Tolist(allproducts[4]),
                Tolist(allproducts[5]),
                Tolist(allproducts[6]),
                Tolist(allproducts[8]),
                Tolist(allproducts[9]),
                Tolist(allproducts[10]),
                Tolist(allproducts[11]),
                Tolist(allproducts[12]),
                Tolist(allproducts[13]),
                Tolist(allproducts[14]),
                Tolist(allproducts[15]),
                Tolist(allproducts[16]),
                Tolist(allproducts[17]),
                Tolist(allproducts[18]),
                Tolist(allproducts[19]),

           };
            // Create a new K-Means algorithm
            KMeans kmeans = new KMeans(k: 3)
            {
                Distance = new WeightedSquareEuclidean(new double[] { 2, 1.7, 1, 1, 1 })
            };

            // Compute and retrieve the data centroids
            var clusters = kmeans.Learn(observations);

            // Use the centroids to parition all the data
            int[] labels = clusters.Decide(observations);
            return labels;
        }

        List<Product> distans()
        {
            List<Product> show = new List<Product>();
            List<Product> allproducts = new List<Product>();
            allproducts.Add((Product)from pd in db.Products where pd.Price > 0 select pd);
            int[] centers = k_means2();
            Product close1 = new Product();
            close1 = allproducts[0];
            foreach (Product p in allproducts)
            {
                if (chackdis(Tolist(p), centers[0]) < chackdis(Tolist(close1), centers[0]))
                    close1 = p;
            }
            show.Add(close1);
            close1 = allproducts[1];
            foreach (Product p in allproducts)
            {
                if (chackdis(Tolist(p), centers[1]) < chackdis(Tolist(close1), centers[1]))
                    close1 = p;
            }
            show.Add(close1);
            close1 = allproducts[2];
            foreach (Product p in allproducts)
            {
                if (chackdis(Tolist(p), centers[2]) < chackdis(Tolist(close1), centers[2]))
                    close1 = p;
            }
            show.Add(close1);
            close1 = allproducts[3];
            foreach (Product p in allproducts)
            {
                if (chackdis(Tolist(p), centers[3]) < chackdis(Tolist(close1), centers[3]))
                    close1 = p;
            }
            show.Add(close1);
            return show;
        }
        public double chackdis(double[] p, int c)
        {
            double sent = (p[0] + p[1] + p[2] + p[3] + p[4]) / 5;
            return sent;
        }
    }
}