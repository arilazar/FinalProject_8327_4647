using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DL;
using BE;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace DL.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void getTagTest()
        {
            Assert.Fail();
        }
        //[TestMethod()]
        //public void GetAPODTest()
        //{
        //    Http http = new Http();
        //    // var ret = await http.getHttp("trump");
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetSearchImagesTest()
        //{
        //    Http http = new Http();
        //    var x = http.GetSearchImages("moon").Result;
        //    ImageSearchResult myDeserializedClass = JsonConvert.DeserializeObject<ImageSearchResult>(x);
        //    IEnumerable<string> res = from item in myDeserializedClass.collection.items
        //            select item.href;

        //    Assert.Fail();
        //}
    }
}
