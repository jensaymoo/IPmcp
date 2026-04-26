namespace IPmcp.App.Services.Rules.Models;

public enum RuleEvent
{
    Unknown = -1,
    OnOpen = 0,
    BeforeAdd = 1,
    AfterAdd = 2,
    BeforeUpdate = 3,
    AfterUpdate = 4,
    BeforeDelete = 5,
    AfterDelete = 6,
    ClientFormOpen = 10,
    ClientDataChange = 11
}
