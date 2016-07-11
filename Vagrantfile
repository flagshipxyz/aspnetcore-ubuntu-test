Vagrant.configure(2) do |config|

  config.vm.define :aspnetcore_test
  config.vm.box = "ubuntu/trusty64"
  config.vm.hostname = "aspnetcore-test"
  config.vm.network "public_network", ip: "192.168.1.120"

  config.vm.provider :virtualbox do |vb|
    vb.memory = "1500"
    vb.name = "aspnetcore-test"
  end

  config.vm.provision "docker" do |d|
  end

  config.vm.provision "shell", inline: <<-SHELL
    sudo -i
    curl -L https://github.com/docker/compose/releases/download/1.6.2/docker-compose-`uname -s`-`uname -m` > /usr/local/bin/docker-compose
    chmod +x /usr/local/bin/docker-compose
  SHELL

end
