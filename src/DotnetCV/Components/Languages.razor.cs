using System.Net.Http.Json;
using DotnetCV.Exceptions;
using Microsoft.AspNetCore.Components;

namespace DotnetCV.Components;

public partial class Languages
{
    [Inject] protected HttpClient HttpClient { get; set; }
    private IEnumerable<Language> _languages;
    private bool _isLoaded;
    
    protected override async Task OnInitializedAsync()
    {
        var me = await HttpClient.GetFromJsonAsync<Language[]>("data/languages.json");
        _languages = me ?? throw new SerializationException("Languages could not be deserialized");
        _isLoaded = true;
    }
}

public record Language(string Name, string Level);