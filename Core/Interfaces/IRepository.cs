using MyCouch;
using MyCouch.Requests;
using MyCouch.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository
    {

        DbConnectionInfo connectionInfo { get; set; }

        /// <summary>
        /// Delete database from couchdb
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatabaseHeaderResponse> DeleteDatabaseAsync(string dbName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get database info
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetDatabaseResponse> GetDatabaseInfoAsync(string dbName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Create database
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DatabaseHeaderResponse> CreateDatabaseAsync(string dbName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Replicate database to target in the same instance
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ReplicationResponse> ReplicateAsync(string id, string source, string target, CancellationToken cancellationToken = default);
        /// <summary>
        /// Replicate database to other instance
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ReplicationResponse> ReplicateAsync(ReplicateDatabaseRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lets you use the underlying bulk API to insert, update and delete documents.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BulkResponse> BulkDocumentAsync(BulkRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Copies the document having a document id matching srcId and rev matching srcRev
        ///     to a new document with a new id being newId. For more options use MyCouch.IDocuments.CopyAsync(MyCouch.Requests.CopyDocumentRequest,System.Threading.CancellationToken)
        ///     instead.
        /// </summary>
        /// <param name="srcId"></param>
        /// <param name="srcRev"></param>
        /// <param name="newId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> CopyDocumentAsync(string srcId, string srcRev, string newId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Copies the document having a document id matching request.SrcId to a new document
        ///     with a new id being request.NewId. You can also specify a specific revision to
        ///     copy via request.SrcRev.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> CopyDocumentAsync(CopyDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Copies the document having a document id matching srcId to a new document with
        ///     a new id being newId. For more options use MyCouch.IDocuments.CopyAsync(MyCouch.Requests.CopyDocumentRequest,System.Threading.CancellationToken)
        ///     instead.
        /// </summary>
        /// <param name="srcId"></param>
        /// <param name="newId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> CopyDocumentAsync(string srcId, string newId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Deletes the document that matches sent request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> DeleteDocumentAsync(DeleteDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Deletes the document that matches sent id and rev.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> DeleteDocumentAsync(string id, string rev, CancellationToken cancellationToken = default);
        /// <summary>
        /// Gets untyped response with the JSON representation of the document.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentResponse> GetDocumentAsync(GetDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Gets untyped response with the JSON representation of the document.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentResponse> GetDocumentAsync(string id, string rev = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Makes a simple HEAD request which doesn not include the actual JSON document,
        /// and returns any matched info for the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> HeadDocumentAsync(HeadDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Makes a simple HEAD request which does not include the actual JSON document,
        /// and returns any matched info for the id and the optional rev.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> HeadDocumentAsync(string id, string rev = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Inserts sent JSON document as it is. Underlying DB will generate _id if non is
        /// provided in doc.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> PostDocumentAsync(string doc, CancellationToken cancellationToken = default);
        /// <summary>
        /// Inserts sent JSON document as it is. Underlying DB will generate _id if non is
        /// provided in Content of request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> PostDocumentAsync(PostDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Inserts or Updates. For updates, doc needs the _rev field.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doc"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> PutDocumentAsync(string id, string doc, CancellationToken cancellationToken = default);
        /// <summary>
        /// Inserts or Updates. If _id in doc is different than the one specified in doc,
        /// the one in id will be used. If _rev in rev is different than the one specified
        /// in doc, the one in rev will be used.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <param name="doc"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> PutDocumentAsync(string id, string rev, string doc, CancellationToken cancellationToken = default);
        /// <summary>
        /// Inserts or Updates. If _id in Content of request is different than the one specified
        /// in Id of request, the one in Id of request will be used. If _rev in Content of
        /// request is different than the one specified in Rev of request, the one in Rev
        /// of request will be used.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> PutDocumentAsync(PutDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Copies the document having a document id matching request.SrcId to a new document
        /// with a new id being request.NewId. You can also specify a specific revision to
        /// copy via request.SrcRev.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> ReplaceDocumentAsync(ReplaceDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Replaces the document having a document id matching trgId and rev trgRev with
        /// the document having id matching srcId and rev matching srcRev.
        /// </summary>
        /// <param name="srcId"></param>
        /// <param name="srcRev"></param>
        /// <param name="trgId"></param>
        /// <param name="trgRev"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> ReplaceDocumentAsync(string srcId, string srcRev, string trgId, string trgRev, CancellationToken cancellationToken = default);
        /// <summary>
        /// Replaces the document having a document id matching trgId and rev trgRev with
        ///  the document having id matching srcId.
        /// </summary>
        /// <param name="srcId"></param>
        /// <param name="trgId"></param>
        /// <param name="trgRev"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> ReplaceDocumentAsync(string srcId, string trgId, string trgRev, CancellationToken cancellationToken = default);
        /// <summary>
        /// Transforms a document with a show function
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RawResponse> ShowDocumentAsync(QueryShowRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Deletes the document that matches the values of the document _id and _rev extracted
        ///     from entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> DeleteEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Gets typed entity-response (MyCouch.Responses.EntityResponse`1 of T) representation
        ///     of the document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetEntityResponse<T>> GetEntityAsync<T>(string id, string rev = null, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Gets typed entity-response (MyCouch.Responses.EntityResponse`1 of T) representation
        ///     of the document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetEntityResponse<T>> GetEntityAsync<T>(GetEntityRequest request, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Inserts sent entity. The resulting JSON that is inserted will have some additional
        ///     meta-data contained in the JSON, like $doctype.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> PostEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Inserts sent entity. The resulting JSON that is inserted will have some additional
        ///     meta-data contained in the JSON, like $doctype.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> PostEntityAsync<T>(PostEntityRequest<T> request, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Inserts (if no _rev is defined) or Updates (if _rev is defined) sent entity and
        ///     returns it in the response, and if successful, then with an updated _rev value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> PutEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Inserts (if no _rev is defined) or Updates (if _rev is defined) sent entity and
        ///     returns it in the response, and if successful, then with an updated _rev value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> PutEntityAsync<T>(string id, T entity, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Inserts (if no _rev is defined) or Updates (if _rev is defined) sent entity and
        ///     returns it in the response, and if successful, then with an updated _rev value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="rev"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> PutEntityAsync<T>(string id, string rev, T entity, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Inserts or Updates sent entity and returns it in the response, and if successful,
        ///     then with an updated _rev value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EntityResponse<T>> PutEntityAsync<T>(PutEntityRequest<T> request, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Lets you perform a query by using a reusable MyCouch.Requests.QueryViewRequest.
        ///     Any returned Value and, or IncludedDoc of the response, will be treated as JSON-strings.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ViewQueryResponse> QueryAsync(QueryViewRequest query, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you perform a query by using a reusable MyCouch.Requests.QueryViewRequest.
        ///     Any returned Value of the response, will be treated as defined by TValue.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ViewQueryResponse<TValue>> QueryAsync<TValue>(QueryViewRequest query, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you perform a query by using a reusable MyCouch.Requests.QueryViewRequest.
        ///     Any returned Value of the response, will be treated as defined by TValue. Any
        ///    returned IncludedDoc of the response, will be treated as defined by TIncludedDoc.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TIncludedDoc"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ViewQueryResponse<TValue, TIncludedDoc>> QueryAsync<TValue, TIncludedDoc>(QueryViewRequest query, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you perform a query, that can be cancelled, and get the result as RAW JSON.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RawResponse> QueryAttachmentRawAsync(QueryViewRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Used to delete an existing attachment.
        /// </summary>
        /// <param name="docId"></param>
        /// <param name="docRev"></param>
        /// <param name="attachmentName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> DeleteAttachmentAsync(string docId, string docRev, string attachmentName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Used to delete an existing attachment.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> DeleteAttachmentAsync(DeleteAttachmentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns only the requested attachment and not the complete document.
        /// </summary>
        /// <param name="docId"></param>
        /// <param name="attachmentName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AttachmentResponse> GetAttachmentAsync(string docId, string attachmentName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns only the requested attachment and not the complete document.
        /// </summary>
        /// <param name="docId"></param>
        /// <param name="docRev"></param>
        /// <param name="attachmentName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AttachmentResponse> GetAttachmentAsync(string docId, string docRev, string attachmentName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns only the requested attachment and not the complete document.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AttachmentResponse> GetAttachmentAsync(GetAttachmentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Used to add an attachment to an existing document.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentHeaderResponse> PutAttachmentAsync(PutAttachmentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you consume changes from the _changes stream.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ChangesResponse> GetAsync(GetChangesRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you consume changes from the _changes stream. Included doc will be deserialized
        ///     as TIncludedDoc.
        /// </summary>
        /// <typeparam name="TIncludedDoc"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ChangesResponse<TIncludedDoc>> GetAsync<TIncludedDoc>(GetChangesRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you consume changes continuously from the _changes stream.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="onRead"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContinuousChangesResponse> GetAsync(GetChangesRequest request, Action<string> onRead, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you consume changes continuously from the _changes stream and handle the
        ///     result in a Task based approach.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="onRead"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContinuousChangesResponse> GetAsync(GetChangesRequest request, Func<string, Task> onRead, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lets you consume changes continuously from the _changes stream.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IObservable<string> ObserveContinuous(GetChangesRequest request, CancellationToken cancellationToken = default);
    }
}