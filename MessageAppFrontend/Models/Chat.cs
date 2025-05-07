using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Models
{
    public class Chat : ObservableObject
    {
        private Guid _id;
        private string _name = null!;
        private List<User> _users = null!;
        private List<Message>? _messages;

        public Guid Id { get => _id; set => SetProperty(ref _id, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public List<User> Users { get => _users; set => SetProperty(ref _users, value); }
        public List<Message> Messages { get => _messages!; set => SetProperty(ref _messages, value); }
    }
}
