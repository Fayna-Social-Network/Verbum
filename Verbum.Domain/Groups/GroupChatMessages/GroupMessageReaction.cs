﻿using Verbum.Domain.Common;

namespace Verbum.Domain.Groups.GroupChatMessages
{
    public class GroupMessageReaction : MessageReaction
    {
        public Guid GroupMessageId { get; set; }
        public GroupMessage? groupMessage { get; set; }
    }
}
