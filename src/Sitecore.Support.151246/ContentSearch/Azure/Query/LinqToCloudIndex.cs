namespace Sitecore.Support.ContentSearch.Azure.Query
{
  using System;
  using System.Collections.Concurrent;
  using System.Reflection;
  using Sitecore.ContentSearch.Linq.Common;
  using Sitecore.ContentSearch.Azure.Query;
  using Sitecore.ContentSearch.Azure;

  public class LinqToCloudIndex<TItem> : Sitecore.ContentSearch.Azure.Query.LinqToCloudIndex<TItem>
  {
    private static FieldInfo fiQueryOptimizer;
    static LinqToCloudIndex()
    {
      var tCloudIndex = typeof(Sitecore.ContentSearch.Azure.Query.CloudIndex<TItem>);
      fiQueryOptimizer = tCloudIndex.GetField("queryOptimizer", BindingFlags.Instance | BindingFlags.NonPublic);
    }

    public LinqToCloudIndex(Sitecore.ContentSearch.Azure.CloudSearchSearchContext context, IExecutionContext executionContext) : base(context, executionContext)
    {
    }

    public LinqToCloudIndex(Sitecore.ContentSearch.Azure.CloudSearchSearchContext context, IExecutionContext[] executionContexts, ServiceCollectionClient serviceCollectionClient) : base(context, executionContexts, serviceCollectionClient)
    {
      fiQueryOptimizer.SetValue(this, new Sitecore.Support.ContentSearch.Azure.Query.CloudQueryOptimizer());      
    }
  }
}