using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using FMBot.Bot.Interfaces;
using FMBot.Persistence.Domain.Models;

namespace FMBot.Bot.Models
{
    public class UserIndexQueue : IUserIndexQueue
    {
        private readonly Subject<IReadOnlyList<User>> _subject;

        public UserIndexQueue()
        {
            this._subject = new Subject<IReadOnlyList<User>>();
            this.UsersToIndex = this._subject.SelectMany(q => q);
        }

        public IObservable<User> UsersToIndex { get; }

        public void Publish(IReadOnlyList<User> users)
        {
            this._subject.OnNext(users);
        }
    }
}
