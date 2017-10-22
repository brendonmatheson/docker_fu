docker run ^
	-it ^
	--rm ^
	--name haproxy-syntax-check ^
	-v W:\wrk\bjm_str_px_docker_dotnet\tasksapp\haproxy\haproxy.cfg:/usr/local/etc/haproxy/haproxy.cfg ^
	library/haproxy:1.7 ^
	haproxy -c -f /usr/local/etc/haproxy/haproxy.cfg
