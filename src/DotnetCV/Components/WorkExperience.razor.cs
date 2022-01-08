using System.Net.Http.Json;
using System.Text;
using DotnetCV.Exceptions;
using Microsoft.AspNetCore.Components;

namespace DotnetCV.Components;

public partial class WorkExperience
{
    [Inject] protected HttpClient HttpClient { get; set; }
    private IEnumerable<Job> _jobs = new List<Job>();
    protected override async Task OnInitializedAsync()
    {
        var jobs = await HttpClient.GetFromJsonAsync<Job[]>("data/jobs.json");
        if (jobs is null) throw new SerializationException("Jobs could not be deserialized");
        _jobs = jobs.OrderByDescending(x => x.From);
    }
    
    public class Job
    {
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public string? Description { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
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