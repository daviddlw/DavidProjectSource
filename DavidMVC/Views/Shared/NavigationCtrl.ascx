<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div>
    <ul class="nav" hid="root">
        <li><a href="/DavidTest/Level1Li" testid="aa">一级li 1</a>
            <ul>
                <li><a href="/DavidTest/Level2Li1" testid="bb">二级 li 1</a></li>
                <li><a href="/DavidTest/Level2Li2" testid="cc">二级 li 2</a>
                    <ul>
                        <li><a href="/DavidTest/Level3Li1" testid="dd">三级 li 1</a></li>
                        <li><a href="/DavidTest/Level3Li2" testid="ee">三级 li 2</a></li>
                        <li><a href="/DavidTest/Level3Li3" testid="ff">三级 li 3</a></li>
                        <li><a href="/DavidTest/Level3Li4" testid="gg">三级 li 4</a></li>
                        <li><a href="/DavidTest/Level3Li5" testid="hh">三级 li 5</a></li>
                        <li><a href="/DavidTest/Level3Li6" testid="ii">三级 li 6</a>
                            <ul>
                                <li><a href="/DavidTest/Level4Li1" testid="jj">四级 li 1</a></li>
                                <li><a href="/DavidTest/Level4Li2" testid="kk">四级 li 2</a></li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li><a href="/DavidTest/Level2Li3" testid="ll">二级 li 3</a>
                    <ul>
                        <li><a href="/DavidTest/Level3Li7" testid="mm">三级 li 7</a></li>
                        <li><a href="/DavidTest/Level3Li8" testid="nn">三级 li 8</a></li>
                        <li><a href="/DavidTest/Level3Li9" testid="oo">三级 li 9</a></li>
                        <li><a href="/DavidTest/Level3Li10" testid="pp">三级 li 10</a></li>
                        <li><a href="/DavidTest/Level3Li11" testid="qq">三级 li 11</a></li>
                    </ul>
                </li>
                <li><a href="/DavidTest/Level2Li4" testid="rr">二级 li 4</a>
                    <ul>
                        <li><a href="/DavidTest/Level3Li12" testid="ss">三级 li 12</a></li>
                        <li><a href="/DavidTest/Level3Li13" testid="tt">三级 li 13</a></li>
                        <li><a href="/DavidTest/Level3Li14" testid="uu">三级 li 14</a></li>
                        <li><a href="/DavidTest/Level3Li15" testid="vv">三级 li 15</a></li>
                        <li><a href="/DavidTest/Level3Li16" testid="ww">三级 li 16</a></li>
                    </ul>
                </li>
            </ul>
        </li>
        <li><a href="/DavidTest/Level1Li2" testid="xx">一级li 2</a>
            <ul>
                <li><a href="/DavidTest/Level2Li5" testid="ss">二级 li 5</a></li>
            </ul>
        </li>
    </ul>
</div>
<script language="javascript" type="text/javascript">

    var nav = new $.fn.jNavigationControl({
        renderTo: $("div[hid='navDiv']")
    });
        
</script>
