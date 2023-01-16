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

		// Program a command that lets the user set the bot to remind 
		
		[Command("remind")]
		public async Task Remind(CommandContext ctx, int min, string subj)
		{
			await ctx.RespondAsync($"Ok, I'll remind you about {subj} in {min} minutes. :ok_hand:");

		}
	}
}

