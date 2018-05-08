---
layout: default
title: FAQ
permalink: faq
---

{% include template-h1.html %}

_Soon availaible_

<ul>
{% for num in (0..site.data.pages.size) %}	
	{% if site.data.pages[num].category == page.permalink and site.data.pages[num].url != page.permalink %}
		<li><a href="{{ site.data.pages[num].url }}">{{ site.data.pages[num].title }}</a></li>
	{% endif %}
{% endfor %}
</ul>
