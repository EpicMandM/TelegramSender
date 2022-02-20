using System;
using System.Linq;
using System.Threading.Tasks;
using TL;
using WTelegram;

namespace TelegramSender
{
    public static class Telegram
    {
        static Client client = new WTelegram.Client(Config);
        /// <summary>
        /// Configure the Client
        /// </summary>
        /// <param name="what">Selector that used at Client's initialization </param>
        static string Config(string what)
        {
            switch (what)
            {
                case "api_id": return "12922019";
                case "api_hash": return "688d18160a144efc8857c6f66b8c1ee7";
                case "phone_number": return "+6283849995719";
                //case "verification_code": Console.Write("Code: "); return Console.ReadLine();
                // IMPORTANT!
                default: return null;
            }
        }
        static User FindPhoneNumber(Contacts_Contacts contacts, string phoneNumber) => contacts.users.First(x => x.Value.phone == phoneNumber).Value;
        /// <summary>
        /// Gets contact and returns user with the specified phone number
        /// </summary>
        /// <param name="client">Initialized client</param>
        /// <param name="phoneNumber">Phone number with +</param>
        /// <returns>User with the specified phone number</returns>
        static async Task<User> GetContact(Client client, string phoneNumber)
        {
            phoneNumber = phoneNumber.Substring(1);
            Contacts_Contacts contacts = await client.Contacts_GetContacts();
            if (contacts.users.Count == 0)
            {
                return null;
            }
            return FindPhoneNumber(contacts, phoneNumber);
        }
        /// <summary>
        /// Sends a message to the phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number with +</param>
        /// <param name="message">Any message</param>
        /// <returns>An instance of Task</returns>
        public static async Task SendMessageAsync(string phoneNumber, string message)
        {
            var my = await client.LoginUserIfNeeded();
            User contact = await GetContact(client, phoneNumber);
            if (contact != null)
            {
                await client.SendMessageAsync(contact.ToInputPeer(), message);
            }
            else
            {
                var contacts = await client.Contacts_ImportContacts(new[]{
                new InputPhoneContact { phone = phoneNumber}
                });
                await client.SendMessageAsync(contacts.users.First(x => x.Value.phone == phoneNumber).Value.ToInputPeer(), message);
            }
        }
    }
}
