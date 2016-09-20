<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <%-- jquery code to show loading panel at proper place--%>
<script src="Scripts/jquery-1.10.2.js"></script>
 <script language="javascript" type="text/javascript">
        function placeUP() {
            var mouseX;
            var mouseY;
            // below line for get mouse position
            $(document).mousemove(function (e) {
                mouseX = e.pageX;
                mouseY = e.pageY;
 
            });
            // below line for show loading panel at proper place
            $('#<%= TreeView1.ClientID%> a').click(function () {
                $('#UP').css({'top': mouseY, 'left': mouseX});
            });
        }
    </script>
    

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Populate Treeview Nodes Dynamically (On Demand)</h3>
     <asp:TextBox ID="ValueText" runat="server" Text="" Width="50%"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Submit" runat="server" OnClick="Button_Click" Text="Find Node" /> 
        <br />
        <br />
    <%-- UpdateProgress is used for show loading panel while loading child nodes --%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div id="UP" style="position:absolute;background-image:url('loading.gif'); background-repeat:no-repeat;
                width:20px;">&nbsp;</div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>       
 
            <script type="text/javascript">
                Sys.Application.add_load(placeUP);
            </script>     
            <%-- Here ExpandDepth="0" for eleminates the expansion of the added treenodes --%>
            <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" NodeIndent="15" PopulateNodesFromClient="false"  PopulateOnDemand="True" OnTreeNodePopulate="TreeView1_TreeNodePopulate">
            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
             <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
               NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
             <ParentNodeStyle Font-Bold="False" />
             <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </ContentTemplate>
    </asp:UpdatePanel>  
</asp:Content>
