(function ($) {
    $.extend($.fn, {
        jNavigationControl: function () {
            var options = $.extend({
                renderTo: $(document.body)
            });

            options.renderTo = (typeof options.renderTo == 'string' ? $(options.renderTo) : options.renderTo);

            //使用时将testid属性换成href属性即可
            var currentUrlHref = window.location.pathname.toLowerCase();

            var root = $("ul[hid='root']");
            $(root).find(">li").attr("first_level", true);
            $(root).find(">li>a").addClass("nav_first_style");

            //递归向下查找可展开元素并且绑定toggle展开事件
            var searchChildren = function (root) {
                if (root.find(">li").length > 0) {
                    $(root).addClass("ul_style");
                    var liChildren = root.find(">li");
                    $(liChildren).each(function (idx, item) {
                        searchChildren($(item));
                    })
                } else if (root.find(">ul").length > 0) {
                    $(root).addClass("li_style");
                    if ($(root).attr("first_level") != true.toString()) {
                        $(root).find(">a").addClass("li_style_a");
                    }

                    var aLink = $(root).find(">a");

                    $(aLink).toggle(function () {
                        $(this).addClass("li_style_a_selected");
                        $(this).parent().find(">ul").show("fast");
                        //                        $(this).parent().find(">ul").removeClass("none");

                        //隐藏非一级节点下的所有兄弟元素
                        if ($(this).parent().attr("first_level") != true.toString()) {
                            $(this).parent().siblings().find(">a").removeClass("li_style_a_selected");
                            $(this).parent().siblings().each(function (idx, item) {
                                removeClassAndHide(item);
                            })
                        } else {
                            $(this).addClass("nav_first_style_selected");
                            $(this).removeClass("li_style_a_selected");
                            $(this).parent().siblings().find(">a").removeClass("nav_first_style_selected");
                            $(this).parent().siblings().each(function (idx, item) {
                                removeClassAndHide(item);
                            })
                        }

                    }, function () {
                        if ($(this).parent().attr("first_level") == true.toString()) {
                            $(this).addClass("nav_first_style_selected");
                            $(this).parent().siblings().find(">a").removeClass("nav_first_style_selected");
                        }
                        removeClassAndHide($(this).parent());
                    })

                    var ulChildren = root.find(">ul");
                    $(ulChildren).each(function (idx, item) {
                        $(item).hide("fast");
                        //                        $(item).addClass("none");
                        searchChildren($(item));
                    });
                } else {
                    if ($(root).attr("first_level") != true.toString()) {
                        $(root).find(">a").addClass("li_style_a");
                    }
                    $(root).addClass("li_style");
                    $(root).click(function () {
                        if ($(root).attr("first_level") != true.toString()) {
                            $(this).find(">a").addClass("li_style_a_selected");
                            $(this).siblings().find(">a").removeClass("li_style_a_selected");
                            $(this).siblings().each(function (idx, item) {
                                removeClassAndHide(item);
                                addFirstLevelClass(item);
                            })
                        } else {
                            $(this).find(">a").addClass("nav_first_style_selected");
                            $(this).find(">a").removeClass("li_style_a_selected");
                            $(this).siblings().find(">a").removeClass("nav_first_style_selected");
                            removeClassAndHide(this);
                        }

                    })
                }
            }


            //搜索初始化位置
            var findInitPosition = function () {
                var currentLi;
                $(root).find("a").each(function (index, aLink) {
                    if (currentUrlHref == $(aLink).attr("href").toString().toLowerCase()) {
                        currentLi = $(aLink).parent();
                    }
                })
                findInit(currentLi);

                $(root).find("ul[expand='true']").each(function (index, item) {
                    //$(item).show("fast");
                })
            }

            //递归查找初始位置
            var findInit = function (currentLi) {
                if ($(currentLi).parent().parent().find(">a").length > 0) {
                    $(currentLi).parent().parent().find(">ul").attr("expand", true);
                    findInit($(currentLi).parent().parent());
                }

                if ($(currentLi).attr("first_level") != true.toString()) {
                    $(currentLi).find(">a").addClass("li_style_a_selected");
                } else {
                    $(currentLi).find(">a").addClass("nav_first_style_selected");
                }
            }

            //递归向下删除所有子节点的选中样式
            var removeClassAndHide = function (li) {
                if ($(li).attr("first_level") != true.toString()) {
                    $(li).find(">a").removeClass("li_style_a_selected");
                    $(li).find(">ul").hide("fast");
                    //                    $(li).find(">ul").addClass("none");

                    if ($(li).find(">ul").length > 0) {
                        $(li).find(">ul>li").each(function (idx, item) {
                            removeClassAndHide(item);
                        });
                    }
                } else if ($(li).attr("first_level") == true.toString()) {
                    $(li).find(">ul").hide("fast");
                    //                    $(li).find(">ul").addClass("none");

                    $(li).find(">ul>li").each(function (idx, item) {
                        removeClassAndHide(item);
                    })
                } else {
                    $(li).find(">ul").show("fast");
                    //                    $(li).find(">ul").removeClass("none");
                    $(li).find(">ul>li").each(function (idx, item) {
                        removeClassAndHide(item);
                    })
                }
            }

            //递归向上添加第一层节点样式
            var addFirstLevelClass = function (li) {
                if ($(li).attr("first_level") != true.toString()) {
                    addFirstLevelClass($(li).parent().parent());
                } else {
                    if (!$(li).find(">a").hasClass("nav_first_style_selected")) {
                        $(li).find(">a").addClass("nav_first_style_selected");
                        $(li).siblings().find(">a").removeClass("nav_first_style_selected");
                    }
                }
            }

            //创建导航
            var createNav = function () {
                searchChildren(root);
                findInitPosition();
            }

            createNav();
        }
    });
})(jQuery)