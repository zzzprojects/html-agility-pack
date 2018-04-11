---
layout: post
---

<html lang="en">
  <head>
  
	<!-- meta !-->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="msvalidate.01" content="89359D9C492A475C0061398008D105FB" />
	
	<!-- seo !-->
	<meta name="description" content="Html Agility Pack | HAP" />
	<meta name="keywords" content="" />
	<title>Html Agility Pack | HAP</title>
		
    <!-- stylesheet -->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
	<link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
	<link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css" />
	<link rel="stylesheet" type="text/css" href="css/style.css" />
	
	<!-- icon !-->
	<link rel="icon" type="image/png" href="http://entityframework-plus.net/images/logo.png" />
	
  </head>
  <body>
  

	<!-- header !-->
	<header class="fixed-top">

		<!-- navbar !-->
		<nav class="container navbar navbar-light navbar-expand-lg">

			<!-- brand !-->
			<a class="navbar-brand" href="{{ site.github.url }}/">
				<img src="http://html-agility-pack.net/images/logo256X256.png">
				Html Agility Pack (<span class="text-z">HAP</span>)
			</a>
		
			<!-- menu mobile !-->
			<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar-menu" aria-controls="navbar-menu" aria-controls="navbar-menu" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>
			
			<!-- menu !-->
			<div class="navbar-collapse collapse justify-content-end" id="navbar-menu">		
				<ul class="navbar-nav">
					<li class="nav-item">
						<a class="nav-link" href="{{ site.github.url }}/tutorials"><i class="fa fa-book" aria-hidden="true"></i>&nbsp;Tutorials</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="https://github.com/zzzprojects/html-agility-pack"><i class="fa fa-github" aria-hidden="true"></i>&nbsp;GitHub</a>
					</li>
							<li class="nav-item">
								<a class="nav-link" href="http://www.zzzprojects.com/contribute" target="_blank"><i class="fa fa-users" aria-hidden="true"></i>&nbsp;Donate</a>
							</li>	
					<li class="nav-item">
						<a class="nav-link" href="{{ site.github.url }}/contact-us"><i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Contact</a>
					</li>
					<li class="nav-item nav-item-download">
						<a class="btn btn-lg btn-z" href="https://www.nuget.org/packages/HtmlAgilityPack/" role="button" onclick="ga('send', 'event', { eventAction: 'download'});"><i class="fa fa-cloud-download" aria-hidden="true"></i>&nbsp;&nbsp;Download&nbsp;<i class="fa fa-angle-right"></i></a>
					</li>
				</ul>
			</div>				
		</nav>

	</header>
	
	<!-- particules !-->
	<div id="particles">
		<div id="particles-js" style="z-index:99;">
			<canvas class="particles-js-canvas-el" style="width: 100%; height: 100%;" width="1903" height="969"></canvas>
		</div>
	</div>
	
	<!-- hero !-->
	<div id="hero">
		<div class="container">
			<div class="row">
			
				<!-- hero-header !-->
				<div class="col-lg-5 hero-header">
				
					<!-- header !-->
					<h1>
						<div class="display-1">HAP</div>
						<div class="display-4">Html Agility Pack</div>
					</h1>
					
					<!-- download !-->
					<div><a class="btn btn-xl btn-z" href="https://www.nuget.org/packages/HtmlAgilityPack/" target="_blank">NuGet Download&nbsp;<i class="fa fa-angle-right"></i></a></div>
					<div class="download-count-text">Download Count:</div>
					<div class="download-count"><img src="https://zzzprojects.github.io/images/nuget/html-agility-pack-big-d.svg" /></div>
					
				</div>
				
				<!-- hero-examples !-->
				<div class="col-lg-7 hero-examples">
				
					<!-- example-1 !-->
					<div class="row wow slideInRight">
					
						<!-- example-1-header !-->
						<div class="col-lg-3"> 
							<h5>LOAD &amp; PARSE HTML</h5>
							<div class="hero-arrow hero-arrow-ltr"><img src="images/hero-arrow.svg"></div>
						</div>
						
						<!-- example-1-code !-->
						<div class="col-lg-9">
							<div class="card card-code card-code-light">
								<div class="card-header">C# HTML Parser Examples</div>
								<div class="card-body">
<pre><span class="code-green">// From File</span>
var doc = new HtmlDocument();
doc.Load(filePath);

<span class="code-green">// From String</span>
var doc = new HtmlDocument();
doc.LoadHtml(html);

<span class="code-green">// From Web</span>
var url = "http://html-agility-pack.net/";
var web = new HtmlWeb();
var doc = web.Load(url);</pre>
								</div>
							</div>
						</div>
					</div>
					
					<!-- example-2 !-->
					<div class="row wow slideInRight">
					
						<!-- example-2-header !-->
						<div class="col-lg-3 order-lg-2">
							<h5>USE SELECTORS, TRAVERSORS, MANIPULATORS, &amp; MORE</h5>
							<div class="hero-arrow hero-arrow-rtl"><img src="images/hero-arrow.svg"></div>
						</div>
						
						<!-- example-2-code !-->
						<div class="col-lg-9 order-lg-1">
							<div class="card card-code card-code-light">
								<div class="card-header">C# HTML Selectors Examples</div>
								<div class="card-body">
<pre><span class="code-green">// With XPath</span>	
var value = doc.DocumentNode
.SelectNodes("//td/input")
.First()
.Attributes["value"].Value;

<span class="code-green">// With LINQ</span>	
var nodes = doc.DocumentNode.Descendants("input")
.Select(y =&gt; y.Descendants()
.Where(x =&gt; x.Attributes["class"].Value == "box"))
.ToList();</pre>
								</div>
							</div>
						</div>						
					</div>
					
				</div>
				
			</div>
		</div>	
	</div>
	
	<!-- keys !-->
	<div id="keys">
		<div class="container">
		
			<!-- keys-header !-->
			<div class="keys-header">
				<h2><i class="fa fa-heart text-z" aria-hidden="true" style="visibility: visible; animation-name: bounceInLeft;"></i>&nbsp;By Millions!</h2>
				<h3>Discover why thousands of developers around the world use Html Agility Pack</h3>
			</div>
			
			<div class="row">
			
				<!-- key-1 !-->
				<div class="col-lg-6 wow slideInLeft">
					<div class="media">
						<i class="fa fa-github"></i>
						<div class="media-body">
							<h5>FREE &amp; Open Source</h5>
							<p>Want to contribute? Access to the full source and help us by providing a pull request.</p>
							<p><a href="https://github.com/zzzprojects/html-agility-pack" target="_blank">GitHub</a></p>
						</div>
					</div>			
				</div>
				
				<!-- key-2 !-->
				<div class="col-lg-6 wow slideInRight">
					<div class="media">
						<i class="fa fa-weixin"></i>
						<div class="media-body">
							<h5>Stack Overflow Support</h5>
							<p>Have a question? Ask questions and find answers from over 2500 questions.</p>
							<p><a href="https://stackoverflow.com/questions/tagged/html-agility-pack" target="_blank">Stack Overflow</a></p>
						</div>
					</div>	
				</div>
			
				<!-- key-3 !-->
				<div class="col-lg-6 wow slideInLeft">
					<div class="media">
						<i class="fa fa-folder-open"></i>
						<div class="media-body">
							<h5>Tutorials &amp; Examples</h5>
							<p>Need help to getting started? Find answers you need through tutorials and online examples.</p>
							<p><a href="tutorials">Tutorials</a></p>
						</div>
					</div>			
				</div>
				
				<!-- key-4 !-->
				<div class="col-lg-6 wow slideInRight">	
					<div class="media">
						<i class="fa fa-bug"></i>
						<div class="media-body">
							<h5>Issue Tracker</h5>
							<p>Found a bug? Have suggestion? Report it and get support from our professional team.</p>
							<p><a href="https://github.com/zzzprojects/html-agility-pack/issues">Issues</a></p>
						</div>
					</div>				
				</div>
				
			</div>	
		</div>
	 </div>
	
	
	<!-- features !-->
	<div id="features">
		<div class="container">

			<h2>Getting Started - <span class="text-z">HTML</span> Agility Pack</h2>

			<div class="arrow arrow-start arrow-start-1 wow fadeInDown" data-wow-delay="1s"><span>&nbsp;</span></div>
			<div class="arrow arrow-start arrow-start-2 wow fadeInDown" data-wow-delay="1s"><span>&nbsp;</span></div>
			<div class="arrow arrow-start arrow-start-3 wow fadeInDown" data-wow-delay="1s"><span>&nbsp;</span></div>
			
			<!-- features-arrow !-->
			<div class="arrow arrow-number wow fadeInDown" data-wow-delay="1s"><span>1</span></div>
			<div class="arrow arrow-middle-to-left-up wow fadeInDown" data-wow-delay="1s"></div>			
			<div class="arrow arrow-middle-to-left-down wow fadeInDown" data-wow-delay="1s"></div>
			<div class="arrow arrow-cursor arrow-cursor-left wow fadeInDown" data-wow-delay="1s"><i class="fa fa-play" aria-hidden="true"></i></div>
			
			<!-- feature 1 !-->
			<div class="row">
			
				<div class="col-lg-4 wow slideInLeft">
					<h3>HTML<span class="text-z"> Parser</span></h3>
					<p>Load and parse HTML</p>
					<ul class="list-content">
						<li><a href="http://html-agility-pack.net/parser">From File</a></li>
						<li><a href="http://html-agility-pack.net/parser">From String</a></li>
						<li><a href="http://html-agility-pack.net/parser">From Web</a></li>				
					</ul>
					
					<div><a href="parser" class="btn btn-z">Html Parser Tutorials</a></div>
				</div>
				
				<div class="col-lg-8 wow slideInRight">
				
						<div class="card card-code card-code-light">
						<div class="card-header"><span class="language">C#</span>&nbsp;<span class="heading">HTML Parser Examples</span></div>
						<div class="card-body">


<pre><span class="code-green">// From File</span>
var doc = new HtmlDocument();
doc.Load(filePath);

<span class="code-green">// From String</span>
var doc = new HtmlDocument();
doc.LoadHtml(html);

<span class="code-green">// From Web</span>
var url = "http://html-agility-pack.net/";
var web = new HtmlWeb();
var doc = web.Load(url);</pre>
						</div>
					</div>
				</div>
			</div>


				<div class="arrow arrow-left-to-right-up wow fadeInDown" data-wow-delay="1s"></div>
				<div class="arrow arrow-number wow fadeInDown" data-wow-delay="1s"><span>2</span></div>
				<div class="arrow arrow-left-to-right-down wow fadeInDown" data-wow-delay="1s"></div>
				<div class="arrow arrow-cursor arrow-cursor-right wow fadeInDown" data-wow-delay="1s"><i class="fa fa-play" aria-hidden="true"></i></div>
				
				<!-- feature 2 !-->
				<div class="row">
					<div class="col-lg-4 order-lg-2 wow slideInRight">
						<h3>HTML<span class="text-z"> Selectors</span></h3>
						<p>Select HtmlNode, Element, and Attributes:</p>
						<ul class="list-content">
							<li><a href="http://html-agility-pack.net/selectors">XPATH</a></li>
							<li><a href="http://html-agility-pack.net/selectors">CSS <i>Coming Soon</i></a></li>		
							<li><a href="http://html-agility-pack.net/selectors">XDocument</a></li>
							<li><a href="http://html-agility-pack.net/selectors">LINQ</a></li>							
						</ul>
						
						<div><a href="selectors" class="btn btn-z">HTML Selectors Tutorials</a></div>
					</div>	
					
					<div class="col-lg-8 wow slideInLeft" >
						<div class="card card-code card-code-light">
							<div class="card-header"><span class="language">C#</span>&nbsp;<span class="heading">HTML Selectors Examples</span></div>
							<div class="card-body">
<pre><span class="code-green">// With XPath</span>	
var value = doc.DocumentNode
	.SelectNodes("//td/input")
	.First()
	.Attributes["value"].Value;
	
<span class="code-green">// With LINQ</span>	
var nodes = doc.DocumentNode.Descendants("input")
	.Select(y =&gt; y.Descendants()
	.Where(x =&gt; x.Attributes["class"].Value == "box"))
	.ToList();</pre>
							</div>
						</div>
					</div>

				</div>


				<div class="arrow arrow-right-to-left-up wow fadeInDown" data-wow-delay="1s"></div>
				<div class="arrow arrow-number wow fadeInDown" data-wow-delay="1s"><span>3</span></div>
				<div class="arrow arrow-right-to-left-down wow fadeInDown" data-wow-delay="1s"></div>
				<div class="arrow arrow-cursor arrow-cursor-left wow fadeInDown" data-wow-delay="1s"><i class="fa fa-play" aria-hidden="true"></i></div>

				<!-- feature 3 !-->
				<div class="row">
				
					<div class="col-lg-4 wow slideInLeft">
						<h3>HTML<span class="text-z"> Manipulation</span></h3>
						<p>Manipulate HtmlNode, Element, and Attributes:</p>
						<ul class="list-content">
							<li><a href="http://html-agility-pack.net/manipulation">AppendChild</a></li>
							<li><a href="http://html-agility-pack.net/manipulation">CreateNode</a></li>
							<li><a href="http://html-agility-pack.net/manipulation">InsertAfter</a></li>				
							<li><a href="http://html-agility-pack.net/manipulation">PreprendChild</a></li>
						</ul>
						
						<div><a href="manipulation" class="btn btn-z">HTML Manipulation Tutorials</a></div>
					</div>
					
					<div class="col-lg-8 wow slideInRight">
						<div class="card card-code card-code-light">
							<div class="card-header"><span class="language">C#</span>&nbsp;<span class="heading">HTML Manipulation Examples</span></div>
							<div class="card-body">
<pre>var doc = new HtmlDocument();
doc.LoadHtml(html);

<span class="code-green">// InnerHtml</span>	
var innerHtml = doc.DocumentNode.InnerHtml;

<span class="code-green">// InnerText</span>	
var innerText = doc.DocumentNode.InnerText;</pre>
							</div>
						</div>
					</div>					
				</div>

				<div class="arrow arrow-left-to-right-up wow fadeInDown" data-wow-delay="1s"></div>
				<div class="arrow arrow-number wow fadeInDown" data-wow-delay="1s"><span>4</span></div>
				<div class="arrow arrow-left-to-right-down wow fadeInDown" data-wow-delay="1s"></div>
				<div class="arrow arrow-cursor arrow-cursor-right wow fadeInDown" data-wow-delay="1s"><i class="fa fa-play" aria-hidden="true"></i></div>
				
				<!-- feature 4 !-->
				<div class="row">
				
					<div class="col-lg-4 order-lg-2 wow slideInRight">
						<h3>HTML<span class="text-z"> Traversing</span></h3>
						<p>Traverse HtmlNode, Element, and Attributes:</p>
						<ul class="list-content">
							<li><a href="http://html-agility-pack.net/traversing">ChildNodes</a></li>
							<li><a href="http://html-agility-pack.net/traversing">Descendants()</a></li>
							<li><a href="http://html-agility-pack.net/traversing">Elements()</a></li>
						</ul>		

						<div><a href="traversing" class="btn btn-z">HTML Traversing Tutorials</a></div>			
					</div>	
					
					<div class="col-lg-8 wow slideInLeft">
						<div class="card card-code card-code-light">
							<div class="card-header"><span class="language">C#</span>&nbsp;<span class="heading">HTML Traversing Examples</span></div>
								<div class="card-body">
<pre>var doc = new HtmlDocument();
htmlDoc.LoadHtml(html);

<span class="code-green">// Descendants</span>	
var nodes = doc.DocumentNode.Descendants("input");
</pre>
							</div>
						</div>
					</div>
				</div>

			<div class="arrow arrow-right-to-middle-up wow fadeInDown" data-wow-delay="1s"></div>
			<div class="arrow arrow-right-to-middle-down wow fadeInDown" data-wow-delay="1s"></div>
			<div class="arrow arrow-cursor arrow-cursor-middle wow fadeInDown" data-wow-delay="1s"><i class="fa fa-play" aria-hidden="true"></i></div>
			<div class="more-tutorials"><a href="tutorials" class="btn btn-z btn-lg">More Tutorials &amp; Examples</a></div>

		</div>
	</div>
	
	<footer class="fixed-bottom">
		<center>
			<a class="btn btn-social btn-facebook" href="https://www.facebook.com/sharer/sharer.php?u=http%3A%2F%2Fhtml-agility-pack.net%2F" target="_blank"><i class="fa fa-facebook" aria-hidden="true"></i>&nbsp;Share on Facebook</a>
			&nbsp;
			<a class="btn btn-social btn-twitter" href="https://twitter.com/intent/tweet?url=http%3A%2F%2Fhtml-agility-pack.net%2F&text=Check out this C# library Html Agility Pack:" target="_blank"><i class="fa fa-twitter" aria-hidden="true"></i>&nbsp;Share on Twitter</a>
		</center>
	</footer>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
	<script src="https://zzzprojects.github.io/html-agility-pack-dev/css/particles.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/wow/1.1.2/wow.min.js"></script>
	<!--<script src="https://cdnjs.cloudflare.com/ajax/libs/particlesjs/2.0.2/particles.js"></script>!-->
	
<script>
new WOW().init();
</script>
<script>
/* ---- particles.js config ---- */
particlesJS("particles-js", {
  "particles": {
    "number": {
      "value": 25,
      "density": {
        "enable": true,
        "value_area": 1000
      }
    },
    "color": {
      "value": "#ffffff"
    },
    "shape": {
      "type": "circle",
      "stroke": {
        "width": 0,
        "color": "#000000"
      },
      "polygon": {
        "nb_sides": 5
      },
      "image": {
        "src": "img/github.svg",
        "width": 100,
        "height": 100
      }
    },
    "opacity": {
      "value": 0.5,
      "random": false,
      "anim": {
        "enable": false,
        "speed": 1,
        "opacity_min": 0.1,
        "sync": false
      }
    },
    "size": {
      "value": 3,
      "random": true,
      "anim": {
        "enable": false,
        "speed": 40,
        "size_min": 0.1,
        "sync": false
      }
    },
    "line_linked": {
      "enable": true,
      "distance": 150,
      "color": "#ffffff",
      "opacity": 0.4,
      "width": 1
    },
    "move": {
      "enable": true,
      "speed": 6,
      "direction": "none",
      "random": false,
      "straight": false,
      "out_mode": "out",
      "bounce": false,
      "attract": {
        "enable": false,
        "rotateX": 600,
        "rotateY": 1200
      }
    }
  },
  "interactivity": {
    "detect_on": "canvas",
    "events": {
      "onhover": {
        "enable": true,
        "mode": "grab"
      },
      "onclick": {
        "enable": true,
        "mode": "push"
      },
      "resize": true
    },
    "modes": {
      "grab": {
        "distance": 240,
        "line_linked": {
          "opacity": 1
        }
      },
      "bubble": {
        "distance": 400,
        "size": 40,
        "duration": 2,
        "opacity": 8,
        "speed": 3
      },
      "repulse": {
        "distance": 400,
        "duration": 0.4
      },
      "push": {
        "particles_nb": 4
      },
      "remove": {
        "particles_nb": 2
      }
    }
  },
  "retina_detect": true
});
</script>
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-55584370-12', 'auto');
  ga('send', 'pageview');
</script>
  </body>
</html>
