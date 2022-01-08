using System.Net.Http.Json;
using DotnetCV.Exceptions;
using Microsoft.AspNetCore.Components;

namespace DotnetCV.Components;

public partial class Skills
{
    [Inject] protected HttpClient HttpClient { get; set; }
    private IEnumerable<Skill> _skills;
    private bool _isLoaded;
    
    protected override async Task OnInitializedAsync()
    {
        var me = await HttpClient.GetFromJsonAsync<Skill[]>("data/skills.json");
        _skills = me ?? throw new SerializationException("Skills could not be deserialized");
        _isLoaded = true;
    }
}

public record Skill(string Name, string Level);