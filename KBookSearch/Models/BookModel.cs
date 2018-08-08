using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBookSearch.Models
{
    public class BookModel
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int? PageCount { get; set; }
        public double? Rating { get; set; }
        public Google.Apis.Books.v1.Data.Volume.VolumeInfoData.ImageLinksData CoverURL { get; set; }
    }
}