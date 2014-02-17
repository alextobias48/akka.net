﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pigeon.Actor
{
    public class BroadcastActorRef : ActorRef
    {
        private List<ActorRef> actors = new List<ActorRef>();
        public BroadcastActorRef(params ActorRef[] actors)
        {
            this.actors.AddRange(actors);
        }

        public void Add(ActorRef actor)
        {
            this.actors.Add(actor);
        }

        internal void Remove(ActorRef Sender)
        {
            actors.Remove(Sender);
        }

        protected override void TellInternal(object message, ActorRef sender)
        {
            actors.ForEach(a => a.Tell(message, sender));
        }
    }
}
