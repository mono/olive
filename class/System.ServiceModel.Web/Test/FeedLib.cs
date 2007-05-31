using System;
using System.IO;
using System.Xml;
using System.ServiceModel.Syndication;

class FeedLib
{
	public static readonly DateTime FixedChangedDate = new DateTime(2000, 5, 12, 0, 0, 0);

	public static SyndicationFeed EmptyFeed
	{
		get {
			SyndicationFeed f = new SyndicationFeed();
			f.Id = "Id should be guid if not set";
			return f;
		}
	}

	public static SyndicationFeed FeedNoItems
	{
		get {
			SyndicationFeed f = new SyndicationFeed();						
			f.Id = "FeedNoItems";
			f.Title = SyndicationContent.CreatePlaintextTextSyndicationContent("Sample Title");
			return f;
		}
	}

	public static SyndicationFeed FeedWithItems
	{
		get {
			SyndicationFeed f = new SyndicationFeed();						
			f.Id = "Id should be guid if not set";
			f.Title = SyndicationContent.CreatePlaintextTextSyndicationContent("Words in a popular panagram.");
	 
			string words = "The quick brown fox jumps over the lazy dog";
			int indx = 0;
			foreach (string p in words.Split(' '))
				{
					SyndicationItem i = new SyndicationItem();

					i.Id = indx.ToString();
					indx++;

					i.Title = SyndicationContent.CreatePlaintextTextSyndicationContent(p);
					i.Summary = new TextSyndicationContent(String.Format("<b>{0} in bold letters</b>", p), TextSyndicationContentKind.Html);
	
					f.Items.Add(i);
				}

			return f;
		}
	}
}
