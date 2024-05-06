<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateChartAdmin.aspx.cs" MasterPageFile="~/Site.master" Inherits="GenerateChartAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" >
        <div style="margin-left: 4px; background-color: black; height:60px; width: 1177px">

        </div>
        <div style="margin-left: 4px;margin-top: 25px; height: 42px;">

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Requests Report"></asp:Label>
           
                    <div class="container mt-5">
            <canvas id="requestsChart" width="600" height="400"></canvas>
        </div>

            
            <p style="margin-left: 0px; background-color:#343A40; width: 1180px; margin-top: 0px; height: 47px;">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
           </p>
        </div>
    </form>
    <script>
    document.addEventListener("DOMContentLoaded", function () {
        const data = {
            labels: chartData.labels,
            datasets: [{
                label: 'Requests Status',
                data: chartData.statuses.map(status => {
                    switch (status) {
                        case 'Pending': return 0.5;
                        case 'Rejected': return 0.25;
                        case 'Approved': return 1;
                        default: return 0;
                    }
                }),
                backgroundColor: [
                    'rgba(75, 192, 192, 0.6)',
                    'rgba(255, 99, 132, 0.6)',
                    'rgba(255, 206, 86, 0.6)',
                    'rgba(54, 162, 235, 0.6)',
                    'rgba(153, 102, 255, 0.6)'
                ],
                borderColor: [
                    'rgba(75, 192, 192, 1)',
                    'rgba(255, 99, 132, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(153, 102, 255, 1)'
                ],
                borderWidth: 1
            }]
        };

        const statusMap = chartData.statuses;

        const ctx = document.getElementById('requestsChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: false
                    },
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                const index = tooltipItem.dataIndex;
                                return `Status: ${statusMap[index]}`;
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        title: {
                            display: true,
                            text: 'Date Received',
                            color: '#000',
                            font: {
                                size: 14
                            }
                        }
                    },
                    y: {
                        beginAtZero: true,
                        max: 1,
                        title: {
                            display: true,
                            text: 'Status',
                            color: '#000',
                            font: {
                                size: 14
                            }
                        },
                        ticks: {
                            callback: function (value) {
                                switch (value) {
                                    case 0.25: return 'Rejected';
                                    case 0.5: return 'Pending';
                                    case 1: return 'Approved';
                                    default: return '';
                                }
                            }
                        }
                    }
                }
            }
        });
    });
    </script>
</asp:Content>

