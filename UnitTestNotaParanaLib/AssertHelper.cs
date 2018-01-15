using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestNotaParanaLib
{
    public static class AssertHelper
    {
        public static void JsonCollectionAreEqual(ICollection expected, ICollection actual)
        {
            Assert.AreEqual(expected.Count, actual.Count, "As quantidades das coleções não conferem.");
            AssertHelper.JsonAreEqual(expected, actual);
        }

        public static void JsonAreEqual(object expected, object actual)
        {
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
