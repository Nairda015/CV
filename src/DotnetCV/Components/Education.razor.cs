using System.Net.Http.Json;
using System.Text;
using DotnetCV.Exceptions;
using Microsoft.AspNetCore.Components;

namespace DotnetCV.Components;

public partial class Education
{
    [Inject] protected HttpClient HttpClient { get; set; }
    private IEnumerable<School> _education = new List<School>();
    protected override async Task OnInitializedAsync()
    {
        
        var education = await HttpClient.GetFromJsonAsync<School[]>("data/education.json");
        if (education is null) throw new SerializationException("Education could not be deserialized");
        _education = education.OrderByDescending(x => x.From);
    }
    
    public class School
    {
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public bool IsCurrent { get; set; }

        internal string GetTimeStamp()
        {
            var result = From.ToString("MMMM yyyy");
            
            if (IsCurrent)
            {
                result += " - Present";
            }
            else if (To.HasValue)
            {
                result += To.Value.ToString("MMMM yyyy");
            }
            return result;
        }
    }
}