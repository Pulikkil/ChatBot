using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CommerceBot.Dialogs
{
    // Model Id == App Id that you'll find in LUIS Portal
    // Find at: https://www.luis.ai/home/keys 
    // Subscription Key is one of the two keys from your Cognitive Services App.
    // Find at: https://portal.azure.com in the Resource Group where you've created
    // your Cognitive Services resource on the Keys blade.
    [LuisModel("af3bb835-a03d-48bc-8170-e9641fba0863", "36099b62640d4cb5bb181e1db353260a")]
    [Serializable]
    public class AppRootDialog : LuisDialog<object>
    {
        private const string EntityCabana = "Cabana";

        [LuisIntent("Reserve.Cabana")]
        public async Task ReserveCabana(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::ReserveCabana");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityCabana, out EntityRecommendation cabanaRec)
                || cabanaRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in ReserveCabana.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("Shajin,I see you want to book a cabana.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }

        private async Task ResumeAfterHotelServicesDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Thank you. We're all done. What else can I do for you?");

            context.Done<object>(null);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi! Try asking me to 'Book a Cabana'.");

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
    }
}