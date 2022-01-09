using System.Net.Http.Json;
using DotnetCV.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;

namespace DotnetCV.Components;

public partial class PersonalInformation
{
    [Inject] protected HttpClient HttpClient { get; set; }
    private Me _me;
    private bool _isLoaded;
    private int _imgSize = 200;
    
    protected override async Task OnInitializedAsync()
    {
        var me = await HttpClient.GetFromJsonAsync<Me>("data/personalInformation.json");
        _me = me ?? throw new SerializationException("Personal information could not be deserialized");
        _isLoaded = true;
    }
}

public record Me(string FirstName, string LastName, string Email, string Phone, string Position);