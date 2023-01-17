using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace my_first_discord_bot.Commands
{
	public class FirstModule : BaseCommandModule
	{
		[Command("greet")]
		public async Task GreetCommand(CommandContext ctx)
		{
			await ctx.RespondAsync("Ayo wassup!");
		}
		[Command("domi")]
		public async Task DomiCute(CommandContext ctx)
		{
			await ctx.RespondAsync("Yes, Domi is very cute.");
		}

		// Command to send a personal message to a user
		[Command("whisper")]
		public async Task WhisperCommand(CommandContext ctx)
		{
			await ctx.Member.SendMessageAsync("Fuck you :middle_finger:");
			
		}
	}
}

