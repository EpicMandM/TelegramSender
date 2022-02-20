using System;
using System.Linq;
using System.Threading.Tasks;
using TL;
using WTelegram;

namespace TelegramSender
{
    public class Telegram
    {
        static Client client = new WTelegram.Client(Config);
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
        static async Task<User> GetContact(Client client, string phoneNumber)
        {
            phoneNumber = phoneNumber.Substring(1);
            Contacts_Contacts contacts = await client.Contacts_GetContacts();
            if (contacts.users.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < contacts.users.Count; i++)
            {
                foreach (var item in contacts.users.Where(x => x.Value.phone == phoneNumber))
                {
                    return item.Value;
                }
            }
            return null;
        }
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
                foreach (var item in contacts.users.Where(x => x.Value.phone == phoneNumber))
                {
                    await client.SendMessageAsync(item.Value.ToInputPeer(), message);
                }
            }
        }
    }
}
