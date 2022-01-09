using System.Net.Http.Json;
using DotnetCV.Exceptions;
using Microsoft.AspNetCore.Components;

namespace DotnetCV.Components;

public partial class Hobbies
{
    [Inject] protected HttpClient HttpClient { get; set; }
    private IEnumerable<string> _hobbies;
    private bool _isLoaded;
    
    protected override async Task OnInitializedAsync()
    {
        var me = await HttpClient.GetFromJsonAsync<string[]>("data/hobbies.json");
        _hobbies = me ?? throw new SerializationException("Hobbies could not be deserialized");
        _isLoaded = true;
    }
}