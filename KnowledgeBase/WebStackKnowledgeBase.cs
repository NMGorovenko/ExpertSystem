namespace KnowledgeBase;

public class WebStackKnowledgeBase
{
    private IDictionary<SiteType, Func<string>> knoladgeBase;

    public WebStackKnowledgeBase()
    {
        knoladgeBase = new Dictionary<SiteType, Func<string>>
        {
            { SiteType.Lending, () => SelectStack(SiteType.Lending) },
            { SiteType.Shop, () => SelectStack(SiteType.Shop) },
            { SiteType.Parser, () => SelectStack(SiteType.Parser) },
            { SiteType.SocialWeb, () => SelectStack(SiteType.SocialWeb) }
        };
    }

    private ICollection<Technology> technologies = new List<Technology>()
    {
        new Technology("ASP NET CORE", [SiteType.Shop, SiteType.SocialWeb]),
        new Technology("NGINX", [SiteType.Shop, SiteType.SocialWeb, SiteType.Parser, SiteType.Lending]),
        new Technology("Django", [SiteType.Parser]),
        new Technology("PostgreSQL", [SiteType.Shop, SiteType.SocialWeb]),
        new Technology("Wordpress", [SiteType.Lending]),
        new Technology("gRPC", [SiteType.Shop, SiteType.SocialWeb]),
    };

    public string SelectStack(SiteType siteType)
    {
        var stack = technologies
            .Where(x => x.TypesUsed.Contains(siteType))
            .Select(x => x.Name)
            .ToList();

        return string.Join(",", stack);
    }
}