﻿using System;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculator_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if ("1".Equals(ddlLogistics.SelectedValue))
                {
                    CalculatedByBlackCat();
                }
                else if ("2".Equals(ddlLogistics.SelectedValue))
                {
                    CalculatedByHsinchu();
                }
                else if ("3".Equals(ddlLogistics.SelectedValue))
                {
                    CalculatedByPostOffice();
                }
            }
        }

        private void CalculatedByPostOffice()
        {
            ltrLogistics.Text = ddlLogistics.SelectedItem.Text;

            var weight = Convert.ToDouble(txtWeight.Text);
            var feeByWeight = 80 + (weight * 10);

            var width = Convert.ToDouble(txtWidth.Text);
            var length = Convert.ToDouble(txtLength.Text);
            var height = Convert.ToDouble(txtHeight.Text);

            var size = width * length * height;
            var feeBySize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBySize)
            {
                ltrFee.Text = feeByWeight.ToString("C");
            }
            else
            {
                ltrFee.Text = feeBySize.ToString("C");
            }
        }

        private void CalculatedByHsinchu()
        {
            ltrLogistics.Text = ddlLogistics.SelectedItem.Text;

            var width = Convert.ToDouble(txtWidth.Text);
            var length = Convert.ToDouble(txtLength.Text);
            var height = Convert.ToDouble(txtHeight.Text);

            var size = (width * length * height);

            if (length > 100 || width > 100 || height > 100)
            {
                ltrFee.Text = (size * 0.0000353 * 1100 + 500).ToString("C");
            }
            else
            {
                ltrFee.Text = (size * 0.0000353 * 1200).ToString("C");
            }
        }

        private void CalculatedByBlackCat()
        {
            ltrLogistics.Text = ddlLogistics.SelectedItem.Text;

            var weight = Convert.ToDouble(txtWeight.Text);

            if (weight > 20)
            {
                ltrFee.Text = 500.ToString("C");
            }
            else
            {
                ltrFee.Text = (100 + weight * 10).ToString("C");
            }
        }
    }
}