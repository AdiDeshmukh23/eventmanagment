namespace EventManagement.Data.Enums
{
    /// <summary>
    /// Represents the status of a ticket.
    /// </summary>
    public enum TicketStatus
    {
        /// <summary>
        /// Ticket is reserved but not confirmed.
        /// </summary>
        Reserved = 0,

        /// <summary>
        /// Ticket is confirmed and paid for.
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// Ticket has been cancelled.
        /// </summary>
        Cancelled = 2,

        /// <summary>
        /// Ticket has been used to attend the event.
        /// </summary>
        Used = 3
    }
} 