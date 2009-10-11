<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="lunchhunters" generation="1" functional="0" release="0" Id="021ee3ef-3d54-44ce-8abb-abbef9fd8f5b" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="lunchhuntersGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="lunchhunters_WebRole:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/lunchhunters/lunchhuntersGroup/LB:lunchhunters_WebRole:HttpIn" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="lunchhunters_WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRoleInstances" />
          </maps>
        </aCS>
        <aCS name="lunchhunters_WebRole:AccountName" defaultValue="">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRole:AccountName" />
          </maps>
        </aCS>
        <aCS name="lunchhunters_WebRole:AccountSharedKey" defaultValue="">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRole:AccountSharedKey" />
          </maps>
        </aCS>
        <aCS name="lunchhunters_WebRole:BlobStorageEndpoint" defaultValue="">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRole:BlobStorageEndpoint" />
          </maps>
        </aCS>
        <aCS name="lunchhunters_WebRole:QueueStorageEndpoint" defaultValue="">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRole:QueueStorageEndpoint" />
          </maps>
        </aCS>
        <aCS name="lunchhunters_WebRole:TableStorageEndpoint" defaultValue="">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRole:TableStorageEndpoint" />
          </maps>
        </aCS>
        <aCS name="lunchhunters_WebRole:allowInsecureRemoteEndpoints" defaultValue="">
          <maps>
            <mapMoniker name="/lunchhunters/lunchhuntersGroup/Maplunchhunters_WebRole:allowInsecureRemoteEndpoints" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:lunchhunters_WebRole:HttpIn">
          <toPorts>
            <inPortMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/HttpIn" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="Maplunchhunters_WebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRoleInstances" />
          </setting>
        </map>
        <map name="Maplunchhunters_WebRole:AccountName" kind="Identity">
          <setting>
            <aCSMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/AccountName" />
          </setting>
        </map>
        <map name="Maplunchhunters_WebRole:AccountSharedKey" kind="Identity">
          <setting>
            <aCSMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/AccountSharedKey" />
          </setting>
        </map>
        <map name="Maplunchhunters_WebRole:BlobStorageEndpoint" kind="Identity">
          <setting>
            <aCSMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/BlobStorageEndpoint" />
          </setting>
        </map>
        <map name="Maplunchhunters_WebRole:QueueStorageEndpoint" kind="Identity">
          <setting>
            <aCSMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/QueueStorageEndpoint" />
          </setting>
        </map>
        <map name="Maplunchhunters_WebRole:TableStorageEndpoint" kind="Identity">
          <setting>
            <aCSMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/TableStorageEndpoint" />
          </setting>
        </map>
        <map name="Maplunchhunters_WebRole:allowInsecureRemoteEndpoints" kind="Identity">
          <setting>
            <aCSMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole/allowInsecureRemoteEndpoints" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="lunchhunters_WebRole" generation="1" functional="0" release="0" software="G:\Backup\Documents\Visual Studio 2008\Projects\lunchhunters\lunchhunters\obj\Debug\lunchhunters_WebRole\" entryPoint="ucruntime" parameters="Microsoft.ServiceHosting.ServiceRuntime.Internal.WebRoleMain" memIndex="1024" hostingEnvironment="frontend">
            <componentports>
              <inPort name="HttpIn" protocol="http" />
            </componentports>
            <settings>
              <aCS name="AccountName" defaultValue="" />
              <aCS name="AccountSharedKey" defaultValue="" />
              <aCS name="BlobStorageEndpoint" defaultValue="" />
              <aCS name="QueueStorageEndpoint" defaultValue="" />
              <aCS name="TableStorageEndpoint" defaultValue="" />
              <aCS name="allowInsecureRemoteEndpoints" defaultValue="" />
            </settings>
            <resourcereferences>
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <eventstreams>
              <eventStream name="Microsoft.ServiceHosting.ServiceRuntime.RoleManager.Critical" kind="Default" severity="Critical" signature="Basic_string" />
              <eventStream name="Microsoft.ServiceHosting.ServiceRuntime.RoleManager.Error" kind="Default" severity="Error" signature="Basic_string" />
              <eventStream name="Critical" kind="Default" severity="Critical" signature="Basic_string" />
              <eventStream name="Error" kind="Default" severity="Error" signature="Basic_string" />
              <eventStream name="Warning" kind="OnDemand" severity="Warning" signature="Basic_string" />
              <eventStream name="Information" kind="OnDemand" severity="Info" signature="Basic_string" />
              <eventStream name="Verbose" kind="OnDemand" severity="Verbose" signature="Basic_string" />
            </eventstreams>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRoleInstances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="lunchhunters_WebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="a3c3a22f-3697-4fb7-90fa-1de913adda37" ref="Microsoft.RedDog.Contract\ServiceContract\lunchhuntersContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="0ecd2692-7bdd-42f6-bd89-e4c360ecf580" ref="Microsoft.RedDog.Contract\Interface\lunchhunters_WebRole:HttpIn@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/lunchhunters/lunchhuntersGroup/lunchhunters_WebRole:HttpIn" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>