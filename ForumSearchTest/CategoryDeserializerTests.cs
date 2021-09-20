using ForumSearch;
using System;
using System.IO;
using System.Text.Json;
using Xunit;

namespace ForumSearchTest
{
    public class CategoryDeserializerTests
    {
        FileStream openStream;
        CategoryDeserializer deserializer;

        private void openFile(string filename)
        {
            openStream = File.OpenRead(filename);
        }

        [Fact]
        public void CategoryDeserializer_IncorrectJsonPropertyType()
        {
            openFile("Files/incorrectType.json");
            Assert.Throws<JsonException>(() => deserializer = new CategoryDeserializer(JsonDocument.Parse(openStream)));         
        }

        [Fact]
        public void CategoryDeserializer_IncorrectJsonPropertyName()
        {
            openFile("Files/incorrectNaming.json");
            deserializer = new CategoryDeserializer(JsonDocument.Parse(openStream));
            foreach (ForumSearch.Models.Category category in deserializer.Categories)
            {
                Assert.Null(category.CategoryName);
                Assert.Null(category.ForumList);
            }
        }

        [Fact]
        public void CategoryDeserializer_CorrectInputData()
        {
            openFile("Files/categories.json");
            deserializer = new CategoryDeserializer(JsonDocument.Parse(openStream));
            Assert.NotNull(deserializer.Categories);
            Assert.NotEmpty(deserializer.Categories);
            foreach (ForumSearch.Models.Category category in deserializer.Categories)
            {
                Assert.NotNull(category);
                Assert.NotNull(category.CategoryName);
                Assert.NotNull(category.ForumList);
                Assert.NotEmpty(category.ForumList);
                foreach (ForumSearch.Models.Forum forum in category.ForumList)
                {
                    Assert.NotNull(forum.Name);
                    Assert.NotNull(forum.Url);
                }
            }
        }
    }
}
