using Crypto.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Crypto
{
    public partial class FormMain : Form
    {
        private IExchangeRate _binanceExchangeRate;
        private IExchangeRate _bybitExchangeRate;
        private IExchangeRate _kucoinExchangeRate;
        public FormMain()
        {
            _binanceExchangeRate = new BinanceExchangeRate();
            _bybitExchangeRate = new BybitExchangeRate();
            _kucoinExchangeRate = new KucoinExchangeRate();

            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Create a timer and set a two second interval.
            var timer = new System.Timers.Timer();
            timer.Interval = 5000;

            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            timer.AutoReset = true;

            // Start the timer
            timer.Enabled = true;
        }

        private async void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            var lastPrice = (await _binanceExchangeRate.GetBTCUSDT()).ToString();

            if (tbBinance.InvokeRequired)
            {
                tbBinance.Invoke(new MethodInvoker(delegate ()
                {
                    tbBinance.Text = lastPrice;
                }));
            }
            else
            {
                tbBinance.Text = lastPrice;
            }

            lastPrice = (await _bybitExchangeRate.GetBTCUSDT()).ToString();

            if (tbBybit.InvokeRequired)
            {
                tbBybit.Invoke(new MethodInvoker(delegate ()
                {
                    tbBybit.Text = lastPrice;
                }));
            }
            else
            {
                tbBybit.Text = lastPrice;
            }

            lastPrice = (await _kucoinExchangeRate.GetBTCUSDT()).ToString();

            if (tbKucoin.InvokeRequired)
            {
                tbKucoin.Invoke(new MethodInvoker(delegate ()
                {
                    tbKucoin.Text = lastPrice;
                }));
            }
            else
            {
                tbKucoin.Text = lastPrice;
            }
        }
    }
}
