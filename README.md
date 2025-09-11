# How to Build a Loan Calculator Dashboard Using WPF Charts

## Overview

This sample project delves into building an Interactive Loan Calculator Dashboard using **Syncfusion® WPF Charts** and **DataGrid**. This dashboard calculates and visualizes loan breakdowns, EMI, and amortization schedules using real-time user inputs. 

### Key reasons to use Loan Calculator 
- Preview repayment schedules and overall costs before you take a loan, giving you confidence in your choices.
- Try out different loan amounts, interest rates, and tenures to instantly see how each factor affects your monthly payments and total outlay.
- Understand the long-term impact of your borrowing—see how changing the repayment period or amount can make a big difference in your financial journey.

### Configure the Syncfusion® Chart and DataGrid controls
Begin by installing the following NuGet packages:
- [Syncfusion.SfChart.WPF](https://www.nuget.org/packages/Syncfusion.SfChart.WPF)
- [Syncfusion.SfGrid.WPF](https://www.nuget.org/packages/Syncfusion.SfGrid.WPF)

### Define the Model
Set up data models to represent all pertinent aspects of the loan calculation, including annual summaries, monthly breakdowns, and EMI structure.

### Configure Interactive Input Controls
This section of the dashboard lets you adjust key loan parameters using simple, interactive controls designed for clarity and ease of use.

### Visualize Payment Breakdown and Progress with Charts
- The Payment Breakdown feature uses a [Doughnut Chart](https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#doughnut-chart) from Syncfusion WPF SfCharts, giving you a clear, visual representation of your loan’s overall cost.
- The [WPF Stacked Column Chart](https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-column-chart) displays the yearly amounts paid toward principal and interest, stacked for each year.
- The [LineSeries](https://help.syncfusion.com/wpf/charts/seriestypes/lineandstepline) in the chart represents the gradual decrease of the remaining loan balance throughout the repayment schedule.

### Organize Repayment Details in DataGrid
The dashboard’s detailed table, built with Syncfusion’s [WPF SfDataGrid](https://help.syncfusion.com/wpf/datagrid/getting-started), organizes your repayment information in a way that’s easy to understand and review.

When you launch your Loan Calculator sample, you’ll see all your charts and tables update in real time, giving you a clear, professional, and actionable view into your loan scenario.

<img width="1919" height="985" alt="loan calculator dashboard output image" src="https://github.com/user-attachments/assets/4bd0e5ab-e628-4a38-9481-b8de79db4b9b" />

## Troubleshooting

### Path Too Long Exception

If you are facing a "Path too long" exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For a detailed step-by-step guide with relevant code snippets, refer to the blog on [how to build a Loan Calculator Dashboard Using WPF Charts](https://www.syncfusion.com/blogs/post/wpf-charts-dashboard/amp).
