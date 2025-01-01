using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace personalfinancetracker.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
