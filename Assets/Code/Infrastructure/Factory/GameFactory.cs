﻿using Code.Hero;
using Code.Infrastructure.AssetManagment;
using Code.Inputs;
using Code.Logic;
using Code.StaticData;
using Code.UI;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly HeroStaticData _heroData;

        public GameFactory(HeroStaticData heroData)
        {
            _heroData = heroData;
        }

        public GameObject CreateHero(Transform at)
        {
            GameObject heroGameObject = Resources.Load<GameObject>(AssetPath.HeroPath);
            heroGameObject.transform.position = at.position;

            IHealth health = heroGameObject.GetComponent<IHealth>();
            health.Current = _heroData.MaxHealth;
            health.Max = _heroData.MaxHealth;

            IPower power = heroGameObject.GetComponent<IPower>();
            power.Current = _heroData.CurrentPower;
            power.Max = _heroData.MaxPower;

            heroGameObject.GetComponent<HeroAttack>().Damage = _heroData.Damage;

            heroGameObject.GetComponent<HeroMovement>().MovementSpeed = _heroData.MoveSpeed;
            heroGameObject.GetComponent<CameraRotationHandler>().Sensitivity = _heroData.Sensitivity;

            return heroGameObject;
        }

        public GameObject CreateHud(IHealth heroHealth, IPower heroPower)
        {
            GameObject hud = Resources.Load<GameObject>(AssetPath.HudPath);

            hud.GetComponent<ActorHpUI>().State = heroHealth;
            hud.GetComponent<ActorPowerUI>().State = heroPower;

            return hud;
        }
    }
}