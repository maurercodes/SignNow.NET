using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignNow.Net.Internal.Extensions;
using SignNow.Net.Model;
using SignNow.Net.Test;
using UnitTests;

namespace AcceptanceTests
{
    [TestClass]
    public partial class DocumentServiceTest : AuthorizedApiTestBase
    {
        [TestMethod]
        public void ShouldGetDocumentInfo()
        {
            var response = SignNowTestContext.Documents.GetDocumentAsync(TestPdfDocumentId).Result;

            Assert.AreEqual(TestPdfDocumentId, response.Id);
            Assert.AreEqual(1, response.PageCount);
            Assert.AreEqual(PdfFileName, response.OriginalName);
            Assert.AreEqual("DocumentUpload", response.Name);

            Assert.IsNotNull(response.UserId.ValidateId());
            Assert.IsNotNull(response.Created);
            Assert.IsNotNull(response.Updated);

            Assert.IsNull(response.OriginDocumentId);
            Assert.IsNull(response.OriginUserId);

            Assert.IsFalse(response.IsTemplate);
        }

        [TestMethod]
        public void MergeDocuments()
        {
            var doc1 = SignNowTestContext.Documents.GetDocumentAsync(TestPdfDocumentId).Result;
            var doc2 = SignNowTestContext.Documents.GetDocumentAsync(TestPdfDocumentIdWithFields).Result;

            var documents = new List<SignNowDocument> {doc1, doc2};

            var merged = SignNowTestContext.Documents
                .MergeDocumentsAsync("merged-document.pdf", documents).Result;

            Assert.AreEqual("merged-document.pdf", merged.Filename);
            Assert.That.StreamIsPdf(merged.Document);
        }

        [TestMethod]
        public void DocumentHistory()
        {
            var response = SignNowTestContext.Documents
                .GetDocumentHistoryAsync(TestPdfDocumentIdWithFields)
                .Result;

            Assert.IsTrue(response.All(itm => itm.Id.Length == 40));
            Assert.IsTrue(response.All(itm => itm.DocumentId == TestPdfDocumentIdWithFields));
        }

        [TestMethod]
        public void CreateOneTimeDocumentDownloadLink()
        {
            var link = SignNowTestContext.Documents
                .CreateOneTimeDownloadLinkAsync(TestPdfDocumentId).Result;

            Assert.IsNotNull(link.Url);
            StringAssert.Contains(link.Url.Host, "signnow.com");
        }
    }
}
