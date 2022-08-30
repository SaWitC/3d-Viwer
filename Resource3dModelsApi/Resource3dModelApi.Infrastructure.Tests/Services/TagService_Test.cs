using Resource3dModelsApi.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelApi.Infrastructure.Tests.Services
{
    public class TagService_Test
    {
        [TestCase("111,11,222,88,777")]
        [TestCase("111, 11,222, 88,   777   ")]
        [TestCase("111,11,222,88,77  7,,   ,,,")]
        [TestCase(" 1 1 1 , 1 1  ,222 ,8 8@7 7  7,,   @@,")]
        [TestCase("111#11.222@88,77  7,,   ,,,")]

        public void GetStringAndReturnListOfTags(string tagstring)
        {
            //arrange
            List<string> strings = new List<string>() { "111", "11", "222", "88", "777" };
            TagService tagService = new TagService();
            //act
            var res = tagService.SplitToTags(tagstring);
            //accept

            Assert.IsNotNull(res);
            Assert.AreEqual(res.First(), strings.First());
            Assert.AreEqual(res.Count, strings.Count);
        }
    }
}
