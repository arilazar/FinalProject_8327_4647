using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ImageSearchResult
    {
        public Collection collection { get; set; }
    }
    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string render { get; set; }
        public string prompt { get; set; }
    }
    public class Datum
    {
        public string media_type { get; set; }
        public string title { get; set; }
        public string center { get; set; }
        public DateTime date_created { get; set; }
        public string description { get; set; }
        public string nasa_id { get; set; }
        public List<string> keywords { get; set; }
        public string description_508 { get; set; }
        public string secondary_creator { get; set; }
        public string location { get; set; }
        public string photographer { get; set; }
        public List<string> album { get; set; }
    }
    public class Item
    {
        public List<Link> links { get; set; }
        public List<Datum> data { get; set; }
        public string href { get; set; }
    }
    public class Metadata
    {
        public int total_hits { get; set; }
    }
    public class Collection
    {
        public List<Item> items { get; set; }
        public string version { get; set; }
        public Metadata metadata { get; set; }
        public string href { get; set; }
        public List<Link> links { get; set; }
    }
}