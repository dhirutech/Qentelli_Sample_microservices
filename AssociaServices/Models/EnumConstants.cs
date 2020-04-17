namespace AssociaServices.Models
{
    public enum TicketStatus
    {
        NewUnassigned,
        Assigned,
        Inprogress,
        Blocked,
        Completed,
        Overdue
    }

    public enum TicketPriority
    {
        Low,
        Medium,
        High
    }

    public enum TicketSourceType
    {
        Call,
        Email,
        Whatsapp,
        Other
    }

    public enum ClientCommunicationType
    {
        Call,
        Email,
        Whatsapp
    }
}
